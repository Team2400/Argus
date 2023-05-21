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
using PacketClass;

namespace Argus
{
    public partial class Parent : Form
    {
        private NetworkStream m_networkstream;
        private TcpListener m_listener;
        private TcpClient m_client;
        private Thread m_thread;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;
        private bool m_bClientOn = false;
        private bool isSent = false;

        public Packet.IntegerClass m_integerClass;
        public Packet.StringClass m_stringClass;
        //public Packet.UsageClass m_userClass;

        int ChildI;
        string ChildS = "";
        SystemUsage[] ChildU;

        public Parent()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            this.m_client = new TcpClient();
            try
            {
                this.m_client.Connect(this.textBox1.Text, 7777);
            }
            catch
            {
                MessageBox.Show("접속 에러");
                return;
            }
            this.m_bConnect = true;
            label.Text = "서버 접속 성공\n";
            this.m_networkstream = this.m_client.GetStream();
            Client();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Parent_FormClosed(object sender, FormClosedEventArgs e)
        {                     
            this.m_listener.Stop();
            this.m_thread.Abort();
            if (this.m_client != null)
            {
                this.m_client.Close();
            }
            if (this.m_networkstream != null)
            {
                this.m_networkstream.Close();
            }
        }

        private void Parent_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(RUN));
            this.m_thread.Start();
        }

        public void RUN()
        {
            this.m_listener = new TcpListener(7777);
            this.m_listener.Start();

            if (!this.m_bClientOn)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label.Text = "클라이언트 접속 대기중";
                }));
            }

            TcpClient client = this.m_listener.AcceptTcpClient(); //Parent창 켜고 접속 대기중 취소버튼 누르면 오류발생
          

            if (client.Connected)
            {
                this.m_bClientOn = true;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label.Text = "클라이언트 접속";
                }));

                m_networkstream = client.GetStream();
                Server();
            }           
        }

        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public void Server()
        {
            if (!this.m_bClientOn)
            {
                return;
            }
            Packet.IntegerClass ii = new Packet.IntegerClass();
            ii.Type = (int)PacketType.정수형;
            ii.Data = Int32.Parse("2023");
            Packet.Serialize(ii).CopyTo(this.sendBuffer, 0);
            this.Send();

            Packet.StringClass ss = new Packet.StringClass();
            ss.Type = (int)PacketType.텍스트;
            ss.s = "텍스트";
            Packet.Serialize(ss).CopyTo(this.sendBuffer, 0);
            this.Send();

            //Packet.UsageClass u = new Packet.UsageClass();           
            //u.Type = (int)PacketType.클래스;
            //Array arr1 = Array.CreateInstance(typeof(SystemUsage), 12);
            //u.arr = arr1; 
            //Packet.Serialize(u).CopyTo(this.sendBuffer, 0);
            //this.Send();
        }

        public void Client()
        {
            int nRead = 0;
            int n = 0;

            while (this.m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
                }
                catch (Exception e)
                {
                    this.m_bConnect = false;
                    this.m_networkstream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.정수형:
                        {
                            this.m_integerClass = (Packet.IntegerClass)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ChildI = this.m_integerClass.Data;
                            }));
                            break;
                        }
                    case (int)PacketType.텍스트:
                        {
                            this.m_stringClass = (Packet.StringClass)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ChildS = this.m_stringClass.s;
                            }));
                            break;
                        }
                        //case (int)PacketType.클래스:
                        //    {
                        //        this.m_userClass = (Packet.UsageClass)Packet.Desserialize(this.readBuffer);
                        //        this.Invoke(new MethodInvoker(delegate ()
                        //        {
                        //            label.Text = "패킷 전송 성공 : Class Data is "; //+ this.m_userClass.arr;
                        //        }));
                        //        break;
                        //    }
                }
                if(n++ == 1)
                {
                    Child cd = new Child(ChildI, ChildS);
                    DialogResult dResult = cd.ShowDialog();

                    if (dResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("Cancel");
                    }
                    break;
                }             
            }
            
        }
    }
}
