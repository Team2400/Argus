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

namespace Argus
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            //getSystemInfo();
        }

        public void getSystemInfo()
        {
            Usage U = new Usage();
            CpuL.Text = "CPU: " + U.CpuUsage().ToString() + " %"; //cpu 사용량 출력
            MemL.Text = "Memory: " + U.MemUsage().ToString() + " %"; //메모리 사용량 출력
            DiskL.Text = "Disk: " + (U.DiskUsage()).ToString() + " GB"; //디스크 사용량 출력
        }
    }

    public class Usage
    {
        UInt64 Cpu;
        UInt64 Mem;
        double Disk = 0;

        public UInt64 CpuUsage()
        {
            ManagementObjectSearcher cpuusage_info = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject wmi_CPUUSAGE in cpuusage_info.Get())
            {
                Cpu = (UInt64)wmi_CPUUSAGE["PercentProcessorTime"];
            }
            return Cpu;
        }

        public UInt64 MemUsage()
        {
            ManagementObjectSearcher ram_usage = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject wmi_RAMUSAGE in ram_usage.Get())
            {
                Mem = (UInt64)wmi_RAMUSAGE["PercentProcessorTime"];
            }
            return Mem;
        }

        public double DiskUsage()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    Disk += (double)(d.TotalSize - d.AvailableFreeSpace) / 1024 / 1024 / 1024;
                    Disk = Math.Round(Disk, 2);
                }
            }
            return Disk;
        }
    }
}
