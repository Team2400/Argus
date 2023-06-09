﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Argus.src;
using System.Threading.Tasks;
using System.Threading;

namespace Argus
{
    public partial class DashBoard : Form
    {
        Dictionary<MODE, System.Windows.Forms.Timer> timerDictionary;
        Dictionary<MODE, ArgusIngredient> modeToIngredients;

        Thread RegularSenderThread;
        ConnectionManager connectionManager;

        MODE ArgusMode = MODE.SECONDS;

        ChildDashboard childDashboard;
        Dictionary<string, Alert> alertsDictionary;

        bool ForceUpdateChart = false;

        public DashBoard()
        {
            InitializeComponent();

            List<string> labels = new List<string> { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };

            List<LiveCharts.WinForms.CartesianChart> chartList = new List<LiveCharts.WinForms.CartesianChart> { cpuChart, memoryChart, diskChart };

            chartList.ForEach(chart => ArgusChart.makeChart(chart, labels));

            connectionManager = new ConnectionManager();
            connectionManager.ConnectionEstablished += Connection_Established;
            connectionManager.StartListener();

            alertsDictionary = new Dictionary<string, Alert>();

            alertsDictionary.Add("CPU", new Alert { type = "CPU" });
            alertsDictionary.Add("MEM", new Alert { type = "MEM" });
            alertsDictionary.Add("DISK", new Alert { type = "DISK" });
        }

        private void Connection_Established(object sender, ConnectionEstablishedEventArgs e)
        {
            if (e.IsConnected)
            {
                // 연결된 클라이언트에 주기적으로 데이터를 보내는 thread 이다.
                // 클라이언트로 송신해 주는것은 별도의 흐름에서 동작해야한다.
                RegularSenderThread = new Thread(delegate () {
                    while (true)
                    {
                        int LIMIT = 13;
                        var dtoList = modeToIngredients[MODE.SECONDS].usageDAO.selectSysUsage(LIMIT).ToArray();
                        Task.Run(() => { connectionManager.TrySendData(dtoList); });

                        Thread.Sleep(5000);
                    }
                });
                RegularSenderThread.Start();
            } else
            {
                MessageBox.Show("연결 실패");
            }
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            // MODE 값, 초단위, 분단위, 시간단위 를 받아 
            modeToIngredients = ModeToIngredientMapperFactory.Create();
            timerDictionary = new Dictionary<MODE, System.Windows.Forms.Timer>();

            timerDictionary.Add(MODE.SECONDS, new System.Windows.Forms.Timer());
            timerDictionary.Add(MODE.MINUTES, new System.Windows.Forms.Timer());
            timerDictionary.Add(MODE.HOURS, new System.Windows.Forms.Timer());

            foreach (KeyValuePair<MODE, System.Windows.Forms.Timer> kvp in timerDictionary)
            {
                kvp.Value.Tag = getTimerTag(kvp.Key);
                kvp.Value.Interval = modeToIngredients[kvp.Key].interval;
                kvp.Value.Tick += Timer_Work;
                kvp.Value.Start();

                Timer_Work(kvp.Value, e);
            }
        }

        private ChartDTO getChartDTO(IEnumerable<SystemUsageDTO> DTOEnum)
        {
            List<double> cList = new List<double>();
            List<double> mList = new List<double>();
            List<double> dList = new List<double>();

            List<DateTime> timeList = new List<DateTime>();

            foreach (var i in DTOEnum)
            {
                cList.Add(i.CPU);
                mList.Add(i.Memory);
                dList.Add(i.Disk);
                timeList.Add(i.Timestamp);
            }

            return new ChartDTO
            {
                // chart data 가공 시작
                cList = dataModulation(cList, timeList),
                mList = dataModulation(mList, timeList),
                dList = dataModulation(dList, timeList),
            };
        }

        // 시간에 따라 주기적으로 호출되는 함수.
        // 시스템에서 값을 뽑아와서 db 에 넣고, 적절히 가공 후 chart 에 update 까지 한 cycle 을 구동한다.
        private void Timer_Work(object sender, EventArgs e)
        {
            var timerSender = sender as System.Windows.Forms.Timer;
            SystemUsageDAO DAO = modeToIngredients[ArgusMode].usageDAO;
            int count = DAO.GetCollection().Count(); // 현재까지 저장된 DTOEnum의 개수이다.
            count = count > 13 ? 13 : count; // 13개를 limit 으로 잡음.

            // data 가 하나라도 없는 경우에는 if 문을 스킵하여 data 를 넣고 updateChart 하도록 한다.
            // 하나라도 있는 경우에는 마지막 아이템으로 부터 시간차이를 구해서 만일 값을 넣을 때가 아니라면 insert 하는 과정을 넘기도록 한다.
            if (count > 0 && ForceUpdateChart == false)
            {
                DateTime lastData = DAO.selectSysUsage(1).First().Timestamp;
                TimeSpan t = DateTime.Now - lastData;
                bool shouldUpdateOrNot = false;

                switch (ArgusMode)
                {
                    case MODE.SECONDS:
                        // 초단위 작업에서는 해당 로직을 건너뛴다.
                        //shouldUpdateOrNot =  t.TotalSeconds < 5; // 5초
                        break;
                    case MODE.MINUTES:
                        shouldUpdateOrNot = t.TotalMinutes < 5; // 5분
                        break;
                    case MODE.HOURS:
                        shouldUpdateOrNot = t.TotalHours < 1; // 1시간
                        break;
                }

                if (shouldUpdateOrNot)
                {
                    return;
                }
            }


            Dictionary<string, int> usageDict = new Dictionary<string, int>();
            usageDict.Add("CPU", SystemUsageManager.getCpuUsage());
            usageDict.Add("MEM", (int)SystemUsageManager.getMemUsage());
            usageDict.Add("DISK", (int)SystemUsageManager.getDiskUsage());

            Task.Run(() =>
            {
                // 알람체크
                foreach (KeyValuePair<string, Alert> kvp in alertsDictionary)
                {
                    var key = kvp.Key;
                    var value = kvp.Value;

                    if (value.initialized == false || value.triggered) { continue; }

                    if (usageDict[key] > value.threshold) 
                    {
                        value.triggered = true;
                        MessageBox.Show(value.message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        value.triggered = false;
                    }
                }
            });

            DAO.insertDB(usageDict["CPU"], usageDict["MEM"], usageDict["DISK"]); //data insert at DB

            // 초단위 timer, 분단위, 시간단위 타이머가 모두 본 eventHandler 를 사용하는데, 모니터에 업데이트 되는 부분은 설정된 mode 에만 동작해야 함
            if ((string)timerSender.Tag != getTimerTag(ArgusMode) && ForceUpdateChart == false) return; 

            ChartDTO chartDTO = getChartDTO(DAO.selectSysUsage(count)); // count 만큼 불러와서 chart 에 업데이트한다.

            // MODE 에 맞는 x축 string
            string title = modeToIngredients[ArgusMode].chartXaxisText;

            ArgusChart.updateChart(cpuChart, chartDTO.cList, title);
            ArgusChart.updateChart(memoryChart, chartDTO.mList, title);
            ArgusChart.updateChart(diskChart, chartDTO.dList, title);

            if (ForceUpdateChart == true) ForceUpdateChart = false;
        }

        /*
        이 함수의 목적은 db 에서 데이터를 불러왔을 때 timestamp diff 가 ArgusMode 에서 정의된 interval 보다 클 경우 0으로 채우기 위함이다.
        예를 들어, 현재 ArgusMode 값이 Seconds 일 경우 5초 간격을 갖는것이 일반적인데, 프로그램이 종료, 실행을 하다보면 diff 가 5초 이상인 경우가 있게된다.
        10초 일 경우에 그 사이에 0인 값이 하나 있어야 자연스러운 그래프가 완성된다.
        따라서 각 data를 받아 필요한 index 에 0을 삽입하여 적절한 그래프 데이터를 리턴하는 함수이다.
        */
        public List<double> dataModulation(List<double> data, List<DateTime> timeList) //data는 가공할 data가 담겨있는 List, timeList는 data의 시간 List, count는 data의 최대 원소 개수
        {
            int OriginalCount = data.Count;
            TimeSpan distanceOfTime = TimeSpan.Zero;
            int timeSpace = 0;

            List<DateTime> time = new List<DateTime>(timeList.Count);

            for (int i = 0; i < timeList.Count; i++)
            {
                time.Add(timeList[i]);
            }
            for (int i = 0; i < OriginalCount - 1; i++)
            {
                distanceOfTime = time[i] - time[i + 1];
                switch(ArgusMode)
                {
                    case MODE.SECONDS:
                        timeSpace = (int)(distanceOfTime.TotalSeconds / 6);
                        break;
                    case MODE.MINUTES:
                        timeSpace = (int)(distanceOfTime.TotalMinutes / 6);
                        break;
                    case MODE.HOURS:
                        timeSpace = (int)(distanceOfTime.TotalHours);
                        break;
                }
                if (timeSpace > 0)
                {
                    for (int j = 0; j < timeSpace; j++)
                    {
                        
                        data.Insert(i + 1, -1);
                        data.RemoveAt(data.Count - 1);
                        time.Insert(i + 1, DateTime.Now);
                        time.RemoveAt(time.Count - 1);
                        i++;// 여기서 data추가 량이 많아지면 오류 발생
                        if (i == OriginalCount - 1)//따라서 0 삽입의 상한을 지정한다
                            break;
                    }
                }
            }

            return data;
        }

        string getTimerTag(MODE mode)
        {
            switch (mode)
            {
                case MODE.SECONDS:
                    return "Sec";
                case MODE.MINUTES:
                    return "Min";
                case MODE.HOURS:
                    return "Hour";
                default:
                    return "Sec";
            }
        }

        private void Infobutton_Click(object sender, EventArgs e)
        {
            showSystemInfo si = new showSystemInfo();
            DialogResult dResult = si.ShowDialog();
            //if (dResult == DialogResult.Cancel)
            //{
            //    MessageBox.Show("Cancel");
            //}
        }

        private void connectButton_Click(object sender, EventArgs e)//Connect to Remote PC 버튼 클릭 이벤트
        {
            IpDialog ipDialog = new IpDialog();
            DialogResult dResult = ipDialog.ShowDialog();
            string ip = ipDialog.ipAddress;

            if (dResult == DialogResult.OK)
            {
                if (childDashboard == null)
                {
                    childDashboard = new ChildDashboard(connectionManager, ip);
                    childDashboard.Show();
                } else
                {
                    childDashboard.Show();
                    childDashboard.ResumeDashboard(ip);
                }
            }
        }

        private void DashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            connectionManager.StopListener();
            connectionManager.CloseServerAcceptedConnection();
            connectionManager.CloseConnection();
        }

        private void ModeBtn_Click(object sender, EventArgs e)
        {
            ModeSelect modeDialog = new ModeSelect(ArgusMode);
            DialogResult result = modeDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ArgusMode = modeDialog.mode;
                // 변경된 모드 반영을 위해 Seconds 가 아니면 한 번 실행시킴.
                ForceUpdateChart = true;
                Timer_Work(timerDictionary[ArgusMode], e);
            }
        }
        public void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button; // sender를 Button 타입으로 형변환
            string key = "CPU";

            if (clickedButton == AlertMem)
            {
                key = "MEM";
            }
            else if (clickedButton == AlertDisk)
            {
                key = "DISK";
            }

            AlertDialog al = new AlertDialog(alertsDictionary[key]);
            DialogResult result = al.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (al.alert.initialized == false)
                {
                    al.alert.initialized = true;
                }
                alertsDictionary[key] = al.alert;
            }
        }
    }
}



