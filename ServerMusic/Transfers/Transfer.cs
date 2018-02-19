using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace ServerMusic.Transfers
{
    class Transfer
    {
        private Server server;
        private Socket socket;

        public Transfer(Server _server, Socket _socket)
        {
            server = _server;
            socket = _socket;
        }

        public string PostRequest(string query)
        {
            string request = $"POST {server.IpPoint.Address}:{server.IpPoint.Port} HTTP/1.1\r\n" +
                $"Content-Length: {query.Length} \r\n" +
                $"Content-Type: application/x-www-form-urlencoded\r\n\r\n" +
                $"{query}\r\n\r\n";

            Byte[] bytesSent = Encoding.UTF8.GetBytes(request);
            Byte[] byteRecived = new Byte[1024];

            socket.Send(bytesSent, bytesSent.Length, 0);

            string page = "";
            int bytes = 0;
            do
            {
                bytes = socket.Receive(byteRecived, byteRecived.Length, 0);
                page = page + Encoding.UTF8.GetString(byteRecived);
            } while (bytes > 0);
            socket.Disconnect(false);

            return page;
        }

        public string Listen()
        {
            Byte[] byteRecived = new Byte[1024];

            string page = "";
            int bytes = 0;
            do
            {
                bytes = socket.Receive(byteRecived, byteRecived.Length, 0);
                page = page + Encoding.UTF8.GetString(byteRecived);
            } while (bytes > 0 && page[page.Length - 1] != '\0');

            Regex reg1 = new Regex(@"..xml version=.*TransferData>", RegexOptions.Singleline);

            return reg1.Match(page).ToString();
        }

        public void SendBackMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            socket.Send(data);
        }
    }
}
