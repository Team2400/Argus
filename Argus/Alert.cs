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
        public event EventHandler Changed;
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
            if(Changed!=null)
            {
                Changed(this, new EventArgs());
            }
            this.Close();

            //MessageBox.Show(message);//이걸 이제 usage 를 추출할 때 마다 검사하여 해당 값보다 클 시 띄움.

            //button cpu를 눌렀을때,
         //   if(Owner.)
            //button mem을 눌렀을 때,
            //button disk를 눌렀을 때 다르게 처리해야되는데..
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //설정한 값 다시 돌리기
        }
    }
}
