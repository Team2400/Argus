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
    public partial class Alert : Form
    {
        private DashBoard ds;

        public Alert()
        {
            InitializeComponent();
        }

        public Alert(DashBoard dash)
        {
            InitializeComponent();
            ds = dash;
            ds.buttonCPU_Click += buttonOk_Click;
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            ds.buttonCPU_Click+= buttonOk_Click;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            ds.setMessage(textBoxThresH.Text,textBoxAlertM.Text);

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {   //텍스트 박스 속 내용 초기화
            textBoxAlertM.Clear();
            textBoxThresH.Clear();
        }

    }
}
