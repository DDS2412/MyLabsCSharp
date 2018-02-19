using System;

namespace ServerMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(3333);
            server.Run();
        }
    }
}
