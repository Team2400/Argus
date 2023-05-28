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
        /*
        private TcpListener m_listener;
        private Thread m_thread;
        private bool m_bClientOn = false;
        private NetworkStream m_networkstream;
        private byte[] sendBuffer = new byte[1024 * 4];

        private TcpClient m_client;
        private bool m_bConnect = false;
        private byte[] readBuffer = new byte[1024 * 4];
       
        public Packet.IntegerClass m_integerClass;
        public Packet.StringClass m_stringClass;
        public Packet.SystemUsage m_usageClass;
        //Child폼으로 전달될 데이터 변수
        int ChildI; 
        string ChildS = "";
        SystemUsageDTO ChildU = new SystemUsageDTO();
        */        

        public string ipAddress { get; set; }

        public IpDialog()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)//Connect 버튼 클릭 이벤트
        {
            /*
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
            */
            ipAddress = ipTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            Close();
        }

        /*
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
        */

        /*
        private void Parent_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(RUN));
            this.m_thread.Start();
        }
        */

        /*
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

            TcpClient client = this.m_listener.AcceptTcpClient(); //Parent창 켜고 접속 대기중 Cancel버튼 누르면 오류발생

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
        */

        /*
        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }
        */


        /*
        public void Server() //데이터 전송 함수
        {
            if (!this.m_bClientOn)
            {
                return;
            }
            //int 데이터 전송
            Packet.IntegerClass ii = new Packet.IntegerClass();
            ii.Type = (int)PacketType.정수형;
            ii.Data = 2023;
            Packet.Serialize(ii).CopyTo(this.sendBuffer, 0);
            this.Send();

            //string 데이터 전송
            Packet.StringClass ss = new Packet.StringClass();
            ss.Type = (int)PacketType.텍스트;
            ss.s = "텍스트";
            Packet.Serialize(ss).CopyTo(this.sendBuffer, 0);
            this.Send();

            //SystemUsage클래스 데이터 전송
            Packet.SystemUsage u = new Packet.SystemUsage();
            u.Type = (int)PacketType.클래스;
            u.CPU = 1.1;
            u.Memory = 2.2;
            u.Disk = 3.3;
            u.Timestamp = DateTime.Now;
            Packet.Serialize(u).CopyTo(this.sendBuffer, 0);
            this.Send();
        }
        */

        /*
        public void Client() //데이터 송신 함수
        {
            int nRead = 0;
            int n = 0;
            const int dataNum = 3; //전송받는 데이터의 개수

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
                    case (int)PacketType.클래스:
                        {
                            this.m_usageClass = (Packet.SystemUsage)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ChildU.CPU = this.m_usageClass.CPU;
                                ChildU.Memory = this.m_usageClass.Memory;
                                ChildU.Disk = this.m_usageClass.Disk;
                                ChildU.Timestamp = this.m_usageClass.Timestamp;
                            }));
                            break;
                        }
                }
                if (n++ == (dataNum-1)) //데이터 전송 완료 후 Child폼 띄움
                {
                    Child cd = new Child(ChildI, ChildS, ChildU);
                    DialogResult dResult = cd.ShowDialog();

                    if (dResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("Cancel");
                    }
                    break;
                }
            }
        }
        */
    }
}
