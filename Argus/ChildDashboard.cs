using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Argus.src;
using PacketClass;

namespace Argus
{
    public partial class ChildDashboard : Form
    {
        ConnectionManager connectionManager;
        public ChildDashboard(ConnectionManager _connectionManager, string ip)
        {
            InitializeComponent();
            connectionManager = _connectionManager;
            connectionManager.ConnectionEstablished += Connection_Established;

            Task.Run(() =>
            {
                connectionManager.TryConnect(ip);

                Packet.SystemUsage usage = connectionManager.ReadDataFromStream();

                if (usage != null)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        label1.Text = usage.CPU.ToString();
                        label2.Text = usage.Memory.ToString();
                        label3.Text = usage.Disk.ToString();
                        label4.Text = usage.Timestamp.ToString();
                    }));
                }
            });
        }
        private void Connection_Established(object sender, ConnectionEstablishedEventArgs e)
        {
            if (!e.isConnected)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    Close();
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            Close();
        }

        private void ChildDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            connectionManager.CloseConnection();
            connectionManager.CloseStream();
        }
    }
}
