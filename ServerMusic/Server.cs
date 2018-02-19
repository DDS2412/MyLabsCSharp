using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ServerMusic.Transfers;

namespace ServerMusic
{
    class Server
    {
        private int port;

        public IPEndPoint IpPoint { get; private set; }

        public Socket ListenSocket { get; private set; }

        public Server(int _port)
        {
            port = _port;
            
            IpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Run()
        {   
            ListenSocket.Bind(IpPoint);

            ListenSocket.Listen(10);

            Console.WriteLine("Waiting...");

            StartListening();
        }

        private void StartListening()
        {
            ServerView serverView = new ServerView();

            while (true)
            {
                Socket handler = ListenSocket.Accept();

                Transfer transfer = new Transfer(this, handler);

                StringBuilder builder = new StringBuilder();

                try
                {
                    do
                    {
                        builder.Append(transfer.Listen());

                        TransferData transferData = TransferData.ConvertToTransferData(builder.ToString());

                        serverView.PerformCommand(transferData, transfer);
                    } while (handler.Available > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
        }
    }
}
