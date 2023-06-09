using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Argus.src;
using PacketClass;

namespace Argus
{
    public partial class ChildDashboard : Form
    {
        ConnectionManager connectionManager;
        System.Windows.Forms.Timer timer;

        public ChildDashboard(ConnectionManager _connectionManager, string ip)
        {
            InitializeComponent();

            // chart init
            List<string> labels = new List<string> { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };
            List<LiveCharts.WinForms.CartesianChart> chartList = new List<LiveCharts.WinForms.CartesianChart> { cpuChart, memoryChart, diskChart };

            chartList.ForEach(chart => ArgusChart.makeChart(chart, labels));

            // connection init
            connectionManager = _connectionManager;
            connectionManager.ConnectionEstablished += Connection_Established;

            timer = new System.Windows.Forms.Timer
            {
                Interval = 5 * 1000,
                Enabled = false,
            };

            connectionManager.TryConnect(ip);

            if (connectionManager.IsConnected == true)
            {
                timer.Tick += TimerTick;
                timer.Enabled = true;
                timer.Start();
            }
        }

        public void ResumeDashboard(string ip)
        {
            connectionManager.TryConnect(ip);
            timer.Start();
        }
        private void Connection_Established(object sender, ConnectionEstablishedEventArgs e)
        {
            if (!e.IsConnected)
            {
                Close();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            List<SystemUsageDTO> usage = connectionManager.ReadDataFromStream();
            if (usage != null)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    var chartDTO = getChartDTO(usage);

                    ArgusChart.updateChart(cpuChart, chartDTO.cList, "seconds ago");
                    ArgusChart.updateChart(memoryChart, chartDTO.mList, "seconds ago");
                    ArgusChart.updateChart(diskChart, chartDTO.dList, "seconds ago");
                }));
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

        public List<double> dataModulation(List<double> data, List<DateTime> timeList) //data는 가공할 data가 담겨있는 List, timeList는 data의 시간 List, count는 data의 최대 원소 개수
        {
            int OriginalCount = 13;
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
                timeSpace = (int)(distanceOfTime.TotalSeconds / 6);

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

        private void ChildDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ChildDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            timer.Stop();
        }
    }
}
