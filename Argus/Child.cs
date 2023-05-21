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
        public int intData;
        public string stringData;
        public Child(int i, string s)
        {
            InitializeComponent();
            intData = i;
            stringData = s;
            label1.Text = "패킷 전송 : Data = " + intData;
            label2.Text = "패킷 전송 : Data = " + stringData;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
