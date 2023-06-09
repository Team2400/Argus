using PacketClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Argus.src
{
    public class ConnectionManager
    {
        TcpListener tcpListener;

        public TcpClient ClientConnection;
        public TcpClient ServerConnection;
        public event EventHandler<ConnectionEstablishedEventArgs> ConnectionEstablished;
        public bool IsConnected { get; set; } = false;
        const int PORT = 7777;

        Stream stream;

        public ConnectionManager()
        {
            ClientConnection = new TcpClient();
            tcpListener = new TcpListener(PORT);
        }

        public void StartListener() { tcpListener.Start(); }

        public void StopListener() 
        {
            if (tcpListener != null) tcpListener.Stop();
        }

        public void TrySendData(SystemUsageDTO[] dtoArray)
        {
            if (ServerConnection == null)
            {
                ServerConnection = tcpListener.AcceptTcpClient();
            }

            if (ServerConnection.Connected)
            {
                try
                {
                    byte[] sendBuffer = new byte[1024 * 4];
                    var stream = ServerConnection.GetStream();

                    //SystemUsage클래스 배열 데이터 전송
                    Packet.SystemUsageDTOArray packetDTO = new Packet.SystemUsageDTOArray();
                    packetDTO.Type = (int)PacketType.ClassArray;
                    packetDTO.arrSize = dtoArray.Length;
                    packetDTO.Arr = new Packet.SystemUsageDTO[dtoArray.Length];

                    for (int i = 0; i < dtoArray.Length; i++)
                    {
                        packetDTO.Arr[i] = new Packet.SystemUsageDTO();
                        packetDTO.Arr[i].CPU = dtoArray[i].CPU;
                        packetDTO.Arr[i].Memory = dtoArray[i].Memory;
                        packetDTO.Arr[i].Disk = dtoArray[i].Disk;
                        packetDTO.Arr[i].Timestamp = dtoArray[i].Timestamp;
                    }

                    Packet.Serialize(packetDTO).CopyTo(sendBuffer, 0);

                    stream.Write(sendBuffer, 0, sendBuffer.Length);
                    stream.Flush();
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void TryConnect(string ip)
        {
            ConnectionEstablishedEventArgs args = new ConnectionEstablishedEventArgs();
            try
            {
                ClientConnection = new TcpClient();
                ClientConnection.Connect(ip, PORT);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                IsConnected = false;
                args.IsConnected = IsConnected;

                OnConnectionEstablished(args);
                return;
            }
            IsConnected = true;
            args.IsConnected = IsConnected;
            stream = ClientConnection.GetStream();

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

            while (IsConnected)
            {
                try
                {
                    //var stream = ClientConnection.GetStream();
                    nRead = 0;
                    nRead = stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch (Exception e)
                {
                    MessageBox.Show("faild to read from stream\n " + e.Message + e.StackTrace);
                    IsConnected = false;
                    return usageList;
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
        public void CloseServerAcceptedConnection()
        {
            if (ServerConnection != null) ServerConnection.Close();
        }

        public void CloseConnection() 
        { 
            if (ClientConnection != null) ClientConnection.Close();
            IsConnected = false;
        }

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
        public bool IsConnected { get; set; }
    }
}
