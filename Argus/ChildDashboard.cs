using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Argus.src;

namespace Argus
{
    public partial class ChildDashboard : Form
    {
        SystemUsageDTO ChildU = new SystemUsageDTO();

        public ChildDashboard(string ip)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            this.Close();
        }
    }
}
