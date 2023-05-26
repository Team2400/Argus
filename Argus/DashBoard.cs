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

            IEnumerable<SystemUsageDTO> data;
            int count = systemUsageDAO.GetCollection().Count() - 1;//현재까지 저장된 data의 개수이다.

            if (count < 13)
            {
                data = systemUsageDAO.selectSysUsage(count);//위 개수만큼 data를 불러온다
            }
            else
            {
                data = systemUsageDAO.selectSysUsage(13);//data가 13개 이상 존재하면 13개 까지만 불러온다
            }

            foreach (var i in data)//data에 대한 list item 추가
            {
                cList.Add(i.CPU);
                mList.Add(i.Memory);
                dList.Add(i.Disk);
            }

            ArgusChart.updateChart(cpuChart, cList);//chart update 이하 동일함
            ArgusChart.updateChart(memoryChart, mList);
            ArgusChart.updateChart(diskChart, dList);
        }
    }
}



