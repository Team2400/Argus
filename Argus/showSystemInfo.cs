using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Argus
{
    public partial class showSystemInfo : Form
    {
        public showSystemInfo()
        {
            InitializeComponent();
            Info();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Info()
        {
            ManagementObjectSearcher os_info = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject wmi_OS in os_info.Get())
            {
                osLabel.Text = "OS : " + wmi_OS["Caption"]; //OS명
            }

            ManagementObjectSearcher cpu_info = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject wmi_CPU in cpu_info.Get())
            {                
                modelLabel.Text = "CPU model : " + wmi_CPU["Name"]; //CPU 모델명
                //freqLabel.Text = "CPU frequency : " + wmi_CPU["MaxClockSpeed"]; //최대 클럭 속도               
                coreLabel.Text = "CPU core : " + wmi_CPU["NumberOfCores"]; //코어 수
                threadLabel.Text = "CPU thread : " + wmi_CPU["ThreadCount"]; //스레드 수
            }

            ManagementObjectSearcher freq_info = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject wmi_F in freq_info.Get())
            {
                double frequency = (uint)wmi_F["CurrentClockSpeed"];                
                frequency /= 1000;
                freqLabel.Text = "CPU frequency : " + frequency + "GHz"; //현재 클럭 속도
            }

            ManagementObjectSearcher mem_info = new ManagementObjectSearcher("Select * from Win32_PhysicalMemory");
            foreach (ManagementObject wmi_MEM in mem_info.Get())
            {
                memLabel.Text = "Memory : " + wmi_MEM["Manufacturer"] + " " + wmi_MEM["PartNumber"]; //메모리 모델명
            }

            ManagementObjectSearcher disk_info = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in disk_info.Get())
            {
                diskLabel.Text = "Disk : " + wmi_HD["Model"]; //Disk 모델명
            }            
        }
    }
}
