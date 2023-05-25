using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Argus
{
    public partial class Child : Form
    {
        int ChildI;
        string ChildS;
        SystemUsage ChildU = new SystemUsage();

        public Child(int i, string s, SystemUsage u)
        {
            InitializeComponent();
            ChildI = i;
            ChildS = s;
            ChildU = u;
            label1.Text = "CPU: " + ChildU.CPU;
            label2.Text = "Mem: " + ChildU.Memory;
            label3.Text = "Disk: " + ChildU.Disk;
            label4.Text = "Timestamp: " + ChildU.Timestamp;
            label5.Text = "Int: " + ChildI;
            label6.Text = "String: " + ChildS;
        }

        private void button1_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            this.Close();
        }
    }
}
