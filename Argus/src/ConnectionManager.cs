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
        SystemUsageDTO[] usageArray; //ChildDashboard폼으로 전달될 데이터 변수

        public event EventHandler<ConnectionEstablishedEventArgs> ConnectionEstablished;

        public bool isConnected { get; set; } = false;
        const int PORT = 7777;

        public ConnectionManager()
        {
            tcpClient = new TcpClient();
            tcpListener = new TcpListener(PORT);
        }

        public void StartListener() { tcpListener.Start(); }

        public void StopListener() 
        {
            if (tcpListener != null) tcpListener.Stop(); 
        }

        public void AcceptConnectionAndStartSendData()
        {
            TcpClient client = tcpListener.AcceptTcpClient();

            if (client.Connected)
            {
                byte[] sendBuffer = new byte[1024 * 4];
                var stream = client.GetStream();

                //SystemUsage클래스 배열 데이터 전송
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

                Packet.Serialize(a).CopyTo(sendBuffer, 0);

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

        public SystemUsageDTO[] ReadDataFromStream()
        {
            int nRead = 0;
            int n = 0;
            const int dataNum = 1; //전송받는 데이터의 개수
            byte[] readBuffer = new byte[1024 * 4];
            Packet.SystemUsageDTOArray usageFromStream = null;

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
                    case (int)PacketType.ClassArray:
                        {
                            usageFromStream = (Packet.SystemUsageDTOArray)Packet.Desserialize(readBuffer);
                            usageArray = new SystemUsageDTO[usageFromStream.arrSize];
                            for (int i = 0; i < usageArray.Length; i++)
                            {
                                usageArray[i] = new SystemUsageDTO();
                                usageArray[i].CPU = usageFromStream.Arr[i].CPU;
                                usageArray[i].Memory = usageFromStream.Arr[i].Memory;
                                usageArray[i].Disk = usageFromStream.Arr[i].Disk;
                                usageArray[i].Timestamp = usageFromStream.Arr[i].Timestamp;
                            }
                            break;
                        }
                }
                if (n++ == (dataNum - 1))
                {
                    break;
                }
            }
            return usageArray;
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
