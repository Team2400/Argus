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
