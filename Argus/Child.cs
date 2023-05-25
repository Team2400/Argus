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
        SystemUsage[] ChildU;

        public Child(int i, string s)
        {
            InitializeComponent();
            ChildI = i;
            ChildS = s;
            label1.Text = "IntData: " + ChildI;
            label2.Text = "StringData: " + ChildS;
            //ChildU = new SystemUsage[12];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
