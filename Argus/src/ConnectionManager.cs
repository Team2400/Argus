using PacketClass;
using System;
using System.Collections.Generic;
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

        public void StopListener() 
        {
            if (tcpListener != null) tcpListener.Stop(); 
        }

        public void AcceptConnectionAndStartSendData()
        {
            TcpClient client = tcpListener.AcceptTcpClient();

            if (isConnected)
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

        public List<SystemUsageDTO> ReadDataFromStream()
        {
            int nRead = 0;
            int n = 0;
            const int dataNum = 1; //전송받는 데이터의 개수
            byte[] readBuffer = new byte[1024 * 4];
            Packet.SystemUsageDTOArray usageFromStream = null;
            List<SystemUsageDTO> usageList = new List<SystemUsageDTO>();

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
                            for (int i = 0; i < usageFromStream.arrSize; i++)
                            {
                                var dto = new SystemUsageDTO
                                {
                                    CPU = usageFromStream.Arr[i].CPU,
                                    Memory = usageFromStream.Arr[i].Memory,
                                    Disk = usageFromStream.Arr[i].Disk,
                                    Timestamp = usageFromStream.Arr[i].Timestamp,
                                };
                                usageList.Add(dto);
                            }
                            break;
                        }
                }
                if (n++ == (dataNum - 1))
                {
                    break;
                }
            }
            return usageList;
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
