using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using PacketClass; //패킷통신 클래스 라이브러리
using Argus.src;

namespace Argus
{    
    public partial class IpDialog : Form
    {
        
        public string ipAddress { get; set; }

        public IpDialog()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)//Connect 버튼 클릭 이벤트
        {
            ipAddress = ipTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            Close();
        }
    }
}
