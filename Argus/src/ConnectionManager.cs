using PacketClass;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Argus.src
{
    public class ConnectionManager
    {
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream stream;

        public event EventHandler<ConnectionEstablishedEventArgs> ConnectionEstablished;

        public bool isConnected { get; set; } = false;
        const int PORT = 7777;

        public ConnectionManager()
        {
            tcpClient = new TcpClient();
            tcpListener = new TcpListener(PORT);
        }

        public void StartListener() { tcpListener.Start(); }

        public void StopListener() { if (tcpListener != null) tcpListener.Stop(); }

        public void AcceptConnectionAndStartSendData()
        {
            TcpClient client = tcpListener.AcceptTcpClient();

            if (client.Connected)
            {
                byte[] sendBuffer = new byte[1024 * 4];
                var stream = client.GetStream();

                //SystemUsage클래스 데이터 전송
                Packet.SystemUsage u = new Packet.SystemUsage();

                u.Type = (int)PacketType.클래스;
                u.CPU = 1.1;
                u.Memory = 2.2;
                u.Disk = 3.3;
                u.Timestamp = DateTime.Now;

                Packet.Serialize(u).CopyTo(sendBuffer, 0);

                stream.Write(sendBuffer, 0, sendBuffer.Length);
                stream.Flush();

                //for (int i = 0; i < 1024 * 4; i++)
                //{
                //    sendBuffer[i] = 0;
                //}
            }
        }

        public void TryConnect(string ip)
        {
            ConnectionEstablishedEventArgs args = new ConnectionEstablishedEventArgs();
            try
            {
                tcpClient.Connect(ip, PORT);
            }
            catch
            {
                isConnected = false;
                args.isConnected = isConnected;

                OnConnectionEstablished(args);
                return;
            }
            isConnected = true;
            stream = tcpClient.GetStream();
            args.isConnected = isConnected;

            OnConnectionEstablished(args);
            return;
        }

        public Packet.SystemUsage ReadDataFromStream()
        {
            int nRead = 0;
            int n = 0;
            const int dataNum = 3; //전송받는 데이터의 개수
            byte[] readBuffer = new byte[1024 * 4];
            Packet.SystemUsage usageFromStream = null;

            while (isConnected)
            {
                try
                {
                    nRead = 0;
                    nRead = stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch (Exception e)
                {
                    isConnected = false;
                    stream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(readBuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.클래스:
                        {
                            usageFromStream = (Packet.SystemUsage)Packet.Desserialize(readBuffer);
                            break;
                        }
                }
                if (n++ == (dataNum - 1))
                {
                    break;
                }
            }

            return usageFromStream;
        }

        public void CloseConnection() { if (tcpClient != null) tcpClient.Close(); }
        public void CloseStream() { if (stream != null) stream.Close(); }

        public void OnConnectionEstablished(ConnectionEstablishedEventArgs e)
        {
            EventHandler<ConnectionEstablishedEventArgs> handler = ConnectionEstablished;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class ConnectionEstablishedEventArgs : EventArgs
    {
        public bool isConnected { get; set; }
    }
}
