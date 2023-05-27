using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Argus.src;

namespace Argus
{
    public partial class Child : Form
    {
        SystemUsageDTO[] ChildA;

        public Child(SystemUsageDTO[] a)
        {
            InitializeComponent();
            ChildA = a;
            for(int i = 0; i < ChildA.Length; i++) 
            {
                textBox1.Text += ChildA[i].CPU + "/" + ChildA[i].Memory + "/" + ChildA[i].Disk + "/" + ChildA[i].Timestamp + "\r\n";
            }            
        }

        private void button1_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            this.Close();
        }
    }
}
