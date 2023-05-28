using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.IO;

using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Argus.src;
using System.Windows.Media.Animation;

namespace Argus
{
    public partial class DashBoard : Form
    {
        private SystemUsageDAO systemUsageDAOMinute;
        private SystemUsageDAO systemUsageDAOHour;
        private SystemUsageDAO systemUsageDAODay;
        public int TIME_INTERVAL_MINUTE = 5 * 1000; //5초
        public int TIME_INTERVAL_HOUR = 5 * 60 * 1000; //5분
        public int TIME_INTERVAL_DAY = 2 * 60 * 60* 1000; //2시간
        private System.Windows.Forms.Timer timerMinute;
        private System.Windows.Forms.Timer timerHour;
        private System.Windows.Forms.Timer timerDay;
        public int checkTimeInterval = 2;//어떤 단위 시간으로 chart를 update할 지 결정하는 변수

        public DashBoard()
        {
            InitializeComponent();

            List<string> labels = new List<string> { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };

            List<LiveCharts.WinForms.CartesianChart> chartList = new List<LiveCharts.WinForms.CartesianChart> { cpuChart, memoryChart, diskChart };

            chartList.ForEach(chart => ArgusChart.makeChart(chart, labels));
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            systemUsageDAOMinute = new SystemUsageDAO("ArgusDBMinute.db", "SystemUsage");
            systemUsageDAOHour = new SystemUsageDAO("ArgusDBHour.db", "SystemUsage");
            systemUsageDAODay = new SystemUsageDAO("ArgusDBDay.db", "SystemUsage");

            timerMinute = new System.Windows.Forms.Timer();
            timerHour = new System.Windows.Forms.Timer();
            timerDay = new System.Windows.Forms.Timer();
            timerMinute.Interval = TIME_INTERVAL_MINUTE;//Time Interval
            timerMinute.Tick += Timer_TickMInute;// 위 시간에 한번씩 Timer_Tick 호출
            timerMinute.Start();
            timerHour.Interval = TIME_INTERVAL_HOUR;//Time Interval
            timerHour.Tick += Timer_TickHour;// 위 시간에 한번씩 Timer_Tick 호출
            timerHour.Start();
            timerDay.Interval = TIME_INTERVAL_DAY;//Time Interval
            timerDay.Tick += Timer_TickDay;// 위 시간에 한번씩 Timer_Tick 호출
            timerDay.Start();
            Timer_TickDay(sender, e);
            Timer_TickHour(sender, e);
            Timer_TickMInute(sender, e);
        }

        private void Timer_TickMInute(object sender, EventArgs e)
        {
            systemUsageDAOMinute.insertDB(
                SystemUsageManager.getCpuUsage(),
                (int)SystemUsageManager.getMemUsage(),
                (int)SystemUsageManager.getDiskUsage()
            );//data insert at DB

            List<double> cList = new List<double>();//CPU chart update를 위한 list 이하 동일함
            List<double> mList = new List<double>();
            List<double> dList = new List<double>();

            List<DateTime> timeList = new List<DateTime>();

            IEnumerable<SystemUsageDTO> data;
            int count = systemUsageDAOMinute.GetCollection().Count() - 1;//현재까지 저장된 data의 개수이다.

            if (count >= 13)//가져올 data의 상한을 정한다.
                count = 13;
            
            data = systemUsageDAOMinute.selectSysUsage(count);//data를 위 count만큼 불러온다

            if (checkTimeInterval != 0)
                return;
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
        private void Timer_TickHour(object sender, EventArgs e)
        {
            if (systemUsageDAOHour.GetCollection().Count() == 0)//기존에 data가 없을 시 무조건 insert
            {
                systemUsageDAOHour.insertDB(
                SystemUsageManager.getCpuUsage(),
                (int)SystemUsageManager.getMemUsage(),
                (int)SystemUsageManager.getDiskUsage()
                );//data insert at DB
            }
            else
            {
                DateTime lastData = systemUsageDAOHour.selectSysUsage(1).First().Timestamp;
                TimeSpan t = DateTime.Now - lastData;
                if (t.TotalMinutes >= 5)//가장 최근 data보다 5분 이상 차이가 나면 data를 insert한다.
                {
                    systemUsageDAOHour.insertDB(
                    SystemUsageManager.getCpuUsage(),
                    (int)SystemUsageManager.getMemUsage(),
                    (int)SystemUsageManager.getDiskUsage()
                    );//data insert at DB
                }
            }

            

            List<double> cList = new List<double>();//CPU chart update를 위한 list 이하 동일함
            List<double> mList = new List<double>();
            List<double> dList = new List<double>();

            List<DateTime> timeList = new List<DateTime>();

            IEnumerable<SystemUsageDTO> data;
            int count = systemUsageDAOHour.GetCollection().Count() - 1;//현재까지 저장된 data의 개수이다.

            if (count >= 13)//가져올 data의 상한을 정한다.
                count = 13;

            data = systemUsageDAOHour.selectSysUsage(count);//data를 위 count만큼 불러온다

            if (checkTimeInterval != 1)
                return;
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
        private void Timer_TickDay(object sender, EventArgs e)
        {
            if (systemUsageDAODay.GetCollection().Count() == 0)
            {
                systemUsageDAODay.insertDB(
                SystemUsageManager.getCpuUsage(),
                (int)SystemUsageManager.getMemUsage(),
                (int)SystemUsageManager.getDiskUsage()
                );//data insert at DB
            }
            else
            {
                DateTime lastData = systemUsageDAODay.selectSysUsage(1).First().Timestamp;
                TimeSpan t = DateTime.Now - lastData;
                if (t.TotalHours >= 2)//가장 최근 data보다 2시간 이상 차이가 나면 data를 insert한다.
                {
                    systemUsageDAODay.insertDB(
                    SystemUsageManager.getCpuUsage(),
                    (int)SystemUsageManager.getMemUsage(),
                    (int)SystemUsageManager.getDiskUsage()
                    );//data insert at DB
                }
            }
            
            List<double> cList = new List<double>();//CPU chart update를 위한 list 이하 동일함
            List<double> mList = new List<double>();
            List<double> dList = new List<double>();

            List<DateTime> timeList = new List<DateTime>();

            IEnumerable<SystemUsageDTO> data;
            int count = systemUsageDAODay.GetCollection().Count() - 1;//현재까지 저장된 data의 개수이다.

            if (count >= 13)//가져올 data의 상한을 정한다.
                count = 13;

            data = systemUsageDAODay.selectSysUsage(count);//data를 위 count만큼 불러온다

            if (checkTimeInterval != 2)
                return;

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

        public List<double> dataModulation(List<double> data, List<DateTime> timeList, int count)//data는 가공할 data가 담겨있는 List, timeList는 data의 시간 List, count는 data의 최대 원소 개수
        {

            TimeSpan destanceOfTime = TimeSpan.Zero;
            int timeSpace = 0;

            List<DateTime> time = new List<DateTime>(timeList.Count);

            for (int i = 0; i < timeList.Count; i++)
            {
                time.Add(timeList[i]);
            }
            for (int i = 0; i < count - 1; i++)
            {
                destanceOfTime = time[i] - time[i + 1];
                switch(checkTimeInterval)
                {
                    case 0:
                        timeSpace = (int)(destanceOfTime.TotalSeconds / 6);
                        break;
                    case 1:
                        timeSpace = (int)(destanceOfTime.TotalMinutes / 6);
                        break;
                    case 2:
                        timeSpace = (int)(destanceOfTime.TotalHours / 3);
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
    }
}



