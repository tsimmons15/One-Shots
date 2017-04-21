using System;
using System.IO;
using MudServer;
using MudServer.Server_Comm;
using MudServer.Properties;

namespace MudBuild
{
    class Program
    {
        public static string GetLocalIPAddress()
        {
            string IP = (Settings.Default.IPAddr != "") ? Settings.Default.IPAddr : "127.0.0.1";
            //TODO: Change this to a DB accessed field
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

            Console.WriteLine("Starting Server {" + IP + ":" + 23 + "}");

            Miscellaneous.server = new Server(IP, 23);
            Miscellaneous.server.StartServer();

            Console.WriteLine("Started");

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
