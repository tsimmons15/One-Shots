using System;
using System.Net;
using System.Net.Sockets;
using MudServer;
using System.IO;
using MudServer.Server_Comm;

namespace MudBuild
{
    class Program
    {
        public static string GetLocalIPAddress()
        {
            string IP = "127.0.0.1";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "IP.txt");
            if (File.Exists(path))
            {
                using (StreamReader read = new StreamReader(path))
                    IP = read.ReadLine();
            }

            return IP;
        }

        static void Main(string[] args)
        {
            string IP = GetLocalIPAddress();

            Miscellaneous.server = new Server(IP, 23);
            Miscellaneous.server.StartServer();
            
            while (Miscellaneous.server.IsListening)
            {
                if (Miscellaneous.server.ConnectionPending)
                {
                    Miscellaneous.server.AcceptConnection();
                }

                Miscellaneous.server.QueryClients();
                
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();

                    Miscellaneous.server.ParseInput(input);
                }
            }
        }
    }
}
