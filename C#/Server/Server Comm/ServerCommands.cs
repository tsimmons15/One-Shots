using MudServer.Server_Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudServer
{
    //public delegate void CommandHandler(byte[] bytes);
    
    public class ServerCommands
    {
        public static Dictionary<string, Action<string[]>> Lookup = new Dictionary<string, Action<string[]>>
        {
            {"exit", COMMAND_EXIT},

            {"connect", COMMAND_CONNECT}
        };

        public static Action<string[]> COMMAND_NOT_FOUND = COMMAND_UNKNOWN;

        private static void COMMAND_UNKNOWN(string[] strings)
        {
            Console.WriteLine("No command {" + strings[0] + "} found");
        }

        public static void COMMAND_EXIT(string[] strings)
        {
            Miscellaneous.server.CloseConnections();
            Miscellaneous.server.StopServer();
            Environment.Exit(0);
        }

        public static void COMMAND_CONNECT(string[] strings)
        {
            //?
        }
    }
}
