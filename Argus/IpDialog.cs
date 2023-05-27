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
        private TcpListener listener;
        private Thread thread;
        private bool bClientOn = false;
        private NetworkStream networkstream;
        private byte[] sendBuffer = new byte[1024 * 4];

        private TcpClient client;
        private bool bConnect = false;
        private byte[] readBuffer = new byte[1024 * 4];

        public Packet.SystemUsageDTOArray usageArrayClass;

        //Child폼으로 전달될 데이터 변수
        SystemUsageDTO[] ChildA;

        public IpDialog()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)//Connect 버튼 클릭 이벤트
        {
            this.client = new TcpClient();
            try
            {
                this.client.Connect(this.textBox1.Text, 7777);
            }
            catch
            {
                MessageBox.Show("접속 에러");
                return;
            }
            this.bConnect = true;
            label.Text = "서버 접속 성공\n";
            this.networkstream = this.client.GetStream();
            ReceiveUsageData();
        }

        private void cancelButton_Click(object sender, EventArgs e)//Cancel 버튼 클릭 이벤트
        {
            this.Close();
        }

        private void Parent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.listener.Stop();
            this.thread.Abort();
            if (this.client != null)
            {
                this.client.Close();
            }
            if (this.networkstream != null)
            {
                this.networkstream.Close();
            }
        }

        private void Parent_Load(object sender, EventArgs e)
        {
            this.thread = new Thread(new ThreadStart(RUN));
            this.thread.Start();
        }

        public void RUN()
        {
            this.listener = new TcpListener(7777);
            this.listener.Start();

            if (!this.bClientOn)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label.Text = "클라이언트 접속 대기중";
                }));
            }

            TcpClient client = this.listener.AcceptTcpClient(); //Parent창 켜고 접속 대기중 Cancel버튼 누르면 오류발생
            try { }catch(Exception ex) { }

            if (client.Connected)
            {
                this.bClientOn = true;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label.Text = "클라이언트 접속";
                }));

                networkstream = client.GetStream();
                SendUsageData();
            }
        }

        public void Send()
        {
            this.networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.networkstream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public void SendUsageData() //데이터 전송 함수
        {
            if (!this.bClientOn)
            {
                return;
            }           
            //SystemUsage클래스 데이터 전송
            Packet.SystemUsageDTOArray a = new Packet.SystemUsageDTOArray();
            a.Type = (int)PacketType.ClassArray;
            a.arrSize = 12;
            a.Arr = new Packet.SystemUsageDTO[a.arrSize];
            double b = 1.1;
            double c = 1.2;
            double d = 1.3;
            for (int i = 0; i < a.Arr.Length; i++)
            {
                a.Arr[i] = new Packet.SystemUsageDTO();
                a.Arr[i].CPU = b;
                a.Arr[i].Memory = c;
                a.Arr[i].Disk = d;
                a.Arr[i].Timestamp = DateTime.Now;
                b += 1; c += 1; d += 1;
            }            
            Packet.Serialize(a).CopyTo(this.sendBuffer, 0);
            this.Send();
        }

        public void ReceiveUsageData() //데이터 송신 함수
        {
            int nRead = 0;
            int n = 0;
            const int dataNum = 1; //전송받는 데이터의 개수

            while (this.bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = this.networkstream.Read(readBuffer, 0, 1024 * 4);
                }
                catch (Exception e)
                {
                    this.bConnect = false;
                    this.networkstream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                switch ((int)packet.Type)
                {                                        
                    case (int)PacketType.ClassArray:
                        {
                            this.usageArrayClass = (Packet.SystemUsageDTOArray)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ChildA = new SystemUsageDTO[usageArrayClass.arrSize];
                                for (int i = 0; i < ChildA.Length; i++)
                                {
                                    ChildA[i] = new SystemUsageDTO();
                                    ChildA[i].CPU = this.usageArrayClass.Arr[i].CPU;
                                    ChildA[i].Memory = this.usageArrayClass.Arr[i].Memory;
                                    ChildA[i].Disk = this.usageArrayClass.Arr[i].Disk;
                                    ChildA[i].Timestamp = this.usageArrayClass.Arr[i].Timestamp;
                                }                                
                            }));
                            break;
                        }                    
                }
                if (n++ == (dataNum-1)) //데이터 전송 완료 후 Child폼 띄움
                {
                    Child cd = new Child(ChildA);
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
