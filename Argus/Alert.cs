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

        public TextBox GetTextBox()
        {
            return this.textBoxThresH;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string message = string.Format("CPU Usage is higher than {0}%!",textBoxThresH.Text);
            textBoxAlertM.Text = message;//threshold를 입력 받으면 밑에 alert message에 출력
            MessageBox.Show(message);//이걸 이제 usage 를 추출할 때 마다 검사하여 해당 값보다 클 시 띄움.
        }
    }
}
