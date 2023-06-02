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
        public Alert()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DashBoard ds = (DashBoard)Owner;
            ds.thres = Convert.ToInt32(textBoxThresH.Text);//int로 형변환
            ds.message = textBoxAlertM.ToString();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {   //텍스트 박스 속 내용 초기화
            textBoxAlertM.Clear();
            textBoxThresH.Clear();
        }

    }
}
