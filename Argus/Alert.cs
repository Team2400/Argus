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
            DashBoard.receivedCPU = textBoxAlertM.ToString();
            DashBoard.tC=textBoxThresH.ToString();

            DashBoard.receivedDISK=textBoxAlertM.ToString();
            DashBoard.tD=textBoxThresH.ToString() ;

            DashBoard.receivedMEM=textBoxAlertM.ToString();
            DashBoard.tM=textBoxThresH.ToString() ;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {   //텍스트 박스 속 내용 초기화
            textBoxAlertM.Clear();
            textBoxThresH.Clear();
        }
    }
}
