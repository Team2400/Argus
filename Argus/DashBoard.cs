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
        private static int ID = 0;
        private LiteDatabase db;
        private ILiteCollection<SystemUsage> collection;
        
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

        private void DashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                db = new LiteDatabase(@"ArgusDB.db");//DB file name(DB Ceate)
                collection = db.GetCollection<SystemUsage>("SystemUsage");//table name(Collection Create)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void insert_DB(int cUsage, int mUsage, int dUsage)//인자로 SystemUsage 3개를 받고 현재 시간과 함께 data삽입
        {
            var data = new SystemUsage { Timestamp = DateTime.Now, CPU = cUsage, Memory = mUsage, Disk = dUsage };
            collection.Insert(data);
        }
        
        private IEnumerable<SystemUsage> selectSysUsage(int limit)//limit는 가장 최근 data부터 얼만큼 값을 불러올 지에 대한 값
            //IEnumerable은 iter가 사용 가능한 자료구조로 만약 각 attribute에 대한 값을 불러오려면 무조건 foreach를 사용하여 접근해야한다. 이하는 그 예시이다.
            //var data = selectSysUsage(5); 최근 data로부터 5개 값을 불러온다
            //foreach (var i in data) foreach문
            //    textBox1.Text +=( "CPU: " + i.CPU.ToString()); 이런식으로 i.CPU로 접근 한 후 원하는 대로 변환하여 사용하면 된다.
        {
            var data = collection.Find(Query.All("Timestamp", Query.Descending), 0, limit);
            return data;
        }

        private void connectButton_Click(object sender, EventArgs e)//Connect to Remote PC 버튼 클릭 이벤트
        {
            Parent pr=new Parent();
            DialogResult dResult=pr.ShowDialog();
            if(dResult == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
            else if(dResult == DialogResult.Cancel)
            {
                MessageBox.Show("Cancel");
            }
        }
    }

    public class SystemUsage//DB에 들어갈 Data format
    {
            public int CPU { get; set; }
            public int Memory { get; set; }
            public int Disk { get; set; }
            public DateTime Timestamp { get; set; }
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



