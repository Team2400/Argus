using System;
using System.Net.Sockets;

namespace Argus.src
{
    public class ConnectionManager
    {
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream stream;
        public event EventHandler<ConnectionEstablishedEventArgs> ConnectionEstablished;

        static int PORT = 7777;

        public ConnectionManager()
        {
            tcpClient = new TcpClient();
            tcpListener = new TcpListener(PORT);
        }

        public void StartListener() { tcpListener.Start(); }

        public void StopListener() { if (tcpListener != null) tcpListener.Stop(); }

        public void TryConnect(string ip)
        {
            ConnectionEstablishedEventArgs args = new ConnectionEstablishedEventArgs();
            try
            {
                tcpClient.Connect(ip, PORT);
            }
            catch
            {
                args.isConnected = false;
                OnConnectionEstablished(args);

                return;
            }
            args.isConnected = true;
            stream = tcpClient.GetStream();
            OnConnectionEstablished(args);
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
