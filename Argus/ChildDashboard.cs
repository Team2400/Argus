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
using System.Windows.Forms;
using Argus.src;

namespace Argus
{
    public partial class ChildDashboard : Form
    {
        public ChildDashboard(ConnectionManager connectionManager, string ip)
        {
            InitializeComponent();
            Task.Run(() =>
            {
                connectionManager.TryConnect(ip);
            });
        }

        private void button1_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            Close();
        }

        private void ChildDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
