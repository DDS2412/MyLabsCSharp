using System;
using System.Net;
namespace ClientMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress serverIP;
            int serverPort;

            try
            {
                if (IPAddress.TryParse(args[0], out serverIP) && int.TryParse(args[1], out serverPort))
                {
                    Client client = new Client(3333, "127.0.0.1");
                    client.Connect();
                }
                else
                {
                    Console.WriteLine("Please, enter port of server and IP of server");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
