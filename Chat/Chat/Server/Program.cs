using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Server";
            var server = new ServerThread();
            server.SetupServer();
            Console.ReadLine();
            server.CloseAllSockets();
        }
    }
}
