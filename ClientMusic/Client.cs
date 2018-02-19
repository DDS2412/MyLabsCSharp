using System;
using System.Net;
using System.Net.Sockets;
using ClientMusic.Transfers;

namespace ClientMusic
{
    class Client
    {
        private Transfer transfer;

        public IPEndPoint IpPoint { get; private set; }
        
        public Socket Socket { get; private set; }

        public Client(int _port, string _address)
        {
            IpPoint = new IPEndPoint(IPAddress.Parse(_address), _port);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            transfer = new Transfer(this);
        }

        public void Connect()
        {
            try
            {
                Socket.Connect(IpPoint);
                UserView.RunClient(transfer);
            }
                catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Socket.Close();
            }
        }
    }
}
