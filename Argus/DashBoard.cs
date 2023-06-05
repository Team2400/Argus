using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Argus.src;

namespace Argus
{
    public partial class DashBoard : Form
    {
        Dictionary<MODE, System.Windows.Forms.Timer> timerDictionary;
        Dictionary<MODE, ArgusIngredient> modeToIngredients;

        MODE ArgusMode = MODE.SECONDS;

        public DashBoard()
        {
            InitializeComponent();

            List<string> labels = new List<string> { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };

            List<LiveCharts.WinForms.CartesianChart> chartList = new List<LiveCharts.WinForms.CartesianChart> { cpuChart, memoryChart, diskChart };

            chartList.ForEach(chart => ArgusChart.makeChart(chart, labels));
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

        private void updateWindows(SystemUsageDAO DAO)
        {
            List<double> cList = new List<double>();//CPU chart update를 위한 list 이하 동일함
            List<double> mList = new List<double>();
            List<double> dList = new List<double>();

            List<DateTime> timeList = new List<DateTime>();

            IEnumerable<SystemUsageDTO> data;
            int count = DAO.GetCollection().Count() - 1;//현재까지 저장된 data의 개수이다.

            if (count >= 13)//가져올 data의 상한을 정한다.
                count = 13;

            data = DAO.selectSysUsage(count);//data를 위 count만큼 불러온다

            //data 가공 시작
            foreach (var i in data)//data에 대한 list item 추가
            {
                cList.Add(i.CPU);
                mList.Add(i.Memory);
                dList.Add(i.Disk);
                timeList.Add(i.Timestamp);
            }

            cList = dataModulation(cList, timeList, count);
            mList = dataModulation(mList, timeList, count);
            dList = dataModulation(dList, timeList, count);

            ArgusChart.updateChart(cpuChart, cList);//chart update 이하 동일함
            ArgusChart.updateChart(memoryChart, mList);
            ArgusChart.updateChart(diskChart, dList);
        }

        // 시간에 따라 주기적으로 호출되는 함수.
        // 시스템에서 값을 뽑아와서 db 에 넣고, 적절히 가공 후 chart 에 update 까지 한 cycle 을 구동한다.
        private void Timer_Work(object sender, EventArgs e)
        {
            var timerSender = sender as System.Windows.Forms.Timer;
            SystemUsageDAO dao = modeToIngredients[ArgusMode].usageDAO;

            // data 가 하나라도 없는 경우에는 if 문을 스킵하여 data 를 넣고 updateChart 하도록 한다.
            // 하나라도 있는 경우에는 마지막 아이템으로 부터 시간차이를 구해서 만일 값을 넣을 때가 아니라면 insert 하는 과정을 넘기도록 한다.
            // TODO 아래 read 를 거치느라 시간이 늦어짐. 개선필요!
            if (dao.GetCollection().Count() != 0)
            {
                DateTime lastData = dao.selectSysUsage(1).First().Timestamp;
                TimeSpan t = DateTime.Now - lastData;
                bool shouldUpdateOrNot = false;

                switch (ArgusMode) 
                {
                    case MODE.SECONDS:
                        shouldUpdateOrNot =  t.TotalSeconds < 5; // 5초
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

            dao.insertDB(
                SystemUsageManager.getCpuUsage(),
                (int)SystemUsageManager.getMemUsage(),
                (int)SystemUsageManager.getDiskUsage()
            ); //data insert at DB

            if ((string)timerSender.Tag != getTimerTag(ArgusMode))
            {
                return;
            }

            updateWindows(dao);
        }

        /*
        이 함수의 목적은 db 에서 데이터를 불러왔을 때 timestamp diff 가 ArgusMode 에서 정의된 interval 보다 클 경우 0으로 채우기 위함이다.
        예를 들어, 현재 ArgusMode 값이 Seconds 일 경우 5초 간격을 갖는것이 일반적인데, 프로그램이 종료, 실행을 하다보면 diff 가 5초 이상인 경우가 있게된다.
        10초 일 경우에 그 사이에 0인 값이 하나 있어야 자연스러운 그래프가 완성된다.
        따라서 각 data를 받아 필요한 index 에 0을 삽입하여 적절한 그래프 데이터를 리턴하는 함수이다.
        */
        public List<double> dataModulation(List<double> data, List<DateTime> timeList, int count) //data는 가공할 data가 담겨있는 List, timeList는 data의 시간 List, count는 data의 최대 원소 개수
        {

            TimeSpan distanceOfTime = TimeSpan.Zero;
            int timeSpace = 0;

            List<DateTime> time = new List<DateTime>(timeList.Count);

            for (int i = 0; i < timeList.Count; i++)
            {
                time.Add(timeList[i]);
            }
            for (int i = 0; i < count - 1; i++)
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
                        timeSpace = (int)(distanceOfTime.TotalHours / 3);
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
                        if (i == count - 1)//따라서 0 삽입의 상한을 지정한다
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
                    return  "Min";
                case MODE.HOURS:
                    return "Hour";
                default:
                    return "Sec";
            }
        }
    }
}



