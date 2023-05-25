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

namespace Argus
{
    public partial class DashBoard : Form
    {
        private SystemUsageDAO systemUsageDAO;
        public int TIME_INTERVAL = 5 * 1000; //5분단위 시간(밀리초) 5 * 60 * 1000
        private System.Windows.Forms.Timer timer;

        public DashBoard()
        {
            InitializeComponent();

            List<string> labels = new List<string> { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };
            List<LiveCharts.WinForms.CartesianChart> chartList = new List<LiveCharts.WinForms.CartesianChart> { cpuChart, memoryChart, diskChart };

            chartList.ForEach(chart => ArgusChart.makeChart(chart, labels));
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            systemUsageDAO = new SystemUsageDAO("ArgusDB.db", "SystemUsage");

            timer = new System.Windows.Forms.Timer();
            timer.Interval = TIME_INTERVAL;//Time Interval
            timer.Tick += Timer_Tick;// 위 시간에 한번씩 Timer_Tick 호출
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            systemUsageDAO.insertDB(
                SystemUsageManager.getCpuUsage(),
                (int)SystemUsageManager.getMemUsage(),
                (int)SystemUsageManager.getDiskUsage()
            );//data insert at DB

            List<double> cList = new List<double>();//CPU chart update를 위한 list 이하 동일함
            List<double> mList = new List<double>();
            List<double> dList = new List<double>();

            List<DateTime> timeList = new List<DateTime>();

            IEnumerable<SystemUsageDTO> data;
            int count = systemUsageDAO.GetCollection().Count() - 1;//현재까지 저장된 data의 개수이다.

            if (count >= 13)//가져올 data의 상한을 정한다.
                count = 13;
            
            data = systemUsageDAO.selectSysUsage(count);//data를 위 count만큼 불러온다

            //data 가공 시작
            foreach (var i in data)//data에 대한 list item 추가
            {   
                cList.Add(i.CPU);
                mList.Add(i.Memory);
                dList.Add(i.Disk);
                timeList.Add(i.Timestamp);
            }

            TimeSpan destanceOfTime = TimeSpan.Zero;
            int timeSpace = 0;

            for(int i = 0; i < count - 1; i++)
            {
                destanceOfTime = timeList[i] - timeList[i+1];
                timeSpace = (int)(destanceOfTime.TotalSeconds / 6);//시간 차이를 계산하여 6초 이상이면 그 만큼 0을 삽입
                if (timeSpace > 0)
                {
                    for(int j = 0; j < timeSpace; j++) 
                    {
                        dList.Insert(i + 1, 0);
                        dList.RemoveAt(dList.Count - 1);
                        cList.Insert(i + 1, 0);
                        cList.RemoveAt(cList.Count - 1);
                        mList.Insert(i + 1, 0);
                        mList.RemoveAt(mList.Count - 1);
                        timeList.Insert(i + 1, DateTime.Now);
                        timeList.RemoveAt(cList.Count - 1);
                        i++;// 여기서 data추가 량이 많아지면 오류 발생
                        if (i == count - 1)//따라서 0 삽입의 상한을 지정한다
                            break;
                    }
                }
            }

            ArgusChart.updateChart(cpuChart, cList);//chart update 이하 동일함
            ArgusChart.updateChart(memoryChart, mList);
            ArgusChart.updateChart(diskChart, dList);
        }

        private void connectButton_Click(object sender, EventArgs e)//Connect to Remote PC 버튼 클릭 이벤트
        {
            Parent pr = new Parent();
            DialogResult dResult = pr.ShowDialog();

            if (dResult == DialogResult.Cancel)
            {
                MessageBox.Show("Cancel");
            }
        }
    }
}



