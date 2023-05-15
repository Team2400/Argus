using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Management;
using System.IO;

using LiveCharts;
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace Argus
{
    public partial class DashBoard : Form
    {
        static void makeChart(LiveCharts.WinForms.CartesianChart someChart, List<string>labels)
        {
            someChart.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = labels,
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 0//x축 label 기울기
            }) ;

            someChart.AxisY.Add(new Axis
            {
                Title = "Usage",
                LabelFormatter = value => value + "%",
                //LabelFormatter = value => value.ToString("P"),//표준형식지정자 (P) 사용
                Separator = new Separator()
            });

        }

        static void updateChart(LiveCharts.WinForms.CartesianChart someChart, List<double> values)
        {
            someChart.Series = new SeriesCollection
            {
                 new LineSeries
                {
                    Values = new ChartValues<double>(values),
                    PointGeometry = null,
                    LineSmoothness = 0//직선
                }
            };
        }

        public DashBoard()
        {
            InitializeComponent();

            List<double> cValues = new List<double> { 6, 7, 3, 4, 6, 5, 3, 2, 6, 7, 8, 7, 5 };
            List<string> labels = new List<string> { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };
            List<LiveCharts.WinForms.CartesianChart> chartList = new List<LiveCharts.WinForms.CartesianChart> { cpuChart, memoryChart, diskChart };

            chartList.ForEach(chart =>
            {
                makeChart(chart, labels);
                updateChart(chart, cValues);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> cValues = new List<double> { 6, 7, 3, 4, 6, 5, 3, 2, 6, 7, 8, 7, 5 };
            updateChart(cpuChart, cValues);
        }
    }

    public class Usage
    {        
        public int getCpuUsage()
        {
            int Cpu = 0;
            ManagementObjectSearcher cpuusage_info = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject wmi_CPUUSAGE in cpuusage_info.Get())
            {
                Cpu = int.Parse(wmi_CPUUSAGE["PercentProcessorTime"].ToString());
            }
            return Cpu;
        }

        public double getMemUsage()
        {
            double Mem;
            double MemSize = 0;
            double MemUsage = 0;
            ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection ram = cls.GetInstances();
            foreach (ManagementObject ram_usage in ram)
            {
                MemSize = int.Parse(ram_usage["TotalVisibleMemorySize"].ToString());
                MemUsage += int.Parse(ram_usage["TotalVisibleMemorySize"].ToString()) - int.Parse(ram_usage["FreePhysicalMemory"].ToString());
            }
            Mem = (double)MemUsage / MemSize;
            Mem = Math.Round(Mem, 4) * 100;
            return Mem;
        }

        public double getDiskUsage()
        {
            double DiskUsage = 0;
            double DiskSize = 0;
            double DiskPerc;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    DiskUsage += (double)(d.TotalSize - d.AvailableFreeSpace) / 1024 / 1024 / 1024;
                    DiskUsage = Math.Round(DiskUsage, 2);
                    DiskSize += d.TotalSize / 1024 / 1024 / 1024;
                    DiskSize = Math.Round(DiskSize, 2);
                }
            }
            DiskPerc = DiskUsage / DiskSize;
            DiskPerc = Math.Round(DiskPerc, 4) * 100;
            return DiskPerc;
        }
    }
}



