using System;
using System.Text;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ClientMusic.Transfers
{
    class Transfer
    {
        private Client client;

        public Transfer(Client _server)
        {
            client = _server;
        }

        public string PostRequest(string query)
        {
            string request = $"POST {client.IpPoint.Address}:{client.IpPoint.Port} HTTP/1.1\r\n" +
                $"Content-Length: {query.Length} \r\n" +
                $"Content-Type: application/x-www-form-urlencoded\r\n\r\n" +
                $"{query}\r\n\r\n";

            Byte[] bytesSent = Encoding.UTF8.GetBytes(request);

            client.Socket.Send(bytesSent, bytesSent.Length, 0);
            
            client.Socket.Disconnect(false);

            return Listen();
        }

        public string Listen()
        {
            Byte[] byteRecived = new Byte[1024];

            string page = "";
            int bytes = 0;
            do
            {
                bytes = client.Socket.Receive(byteRecived, byteRecived.Length, 0);
                page = page + Encoding.UTF8.GetString(byteRecived);
            } while (bytes > 0 && page[page.Length-1] != '\0');
            
            return page.ToString();
        }

        public void SendBackMessage(string message, Socket handler)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            handler.Send(data);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
