using MudServer.Server_Comm;
using System;
using System.Collections.Generic;


namespace MudServer
{
    public class ClientCommands
    {
        public static Dictionary<string, Action<string[], Client>> Lookup = new Dictionary<string, Action<string[], Client>>
        {
                {"quit", COMMAND_QUIT},
                {"say", COMMAND_SAY}
        };

        public static Action<string[], Client> COMMAND_NOT_FOUND = COMMAND_UNKNOWN;

        private static void COMMAND_UNKNOWN(string[] strings, Client client)
        {
            client.Write(Miscellaneous.StringToBytes("No command {" + strings[0] + "} found"));
            Console.WriteLine("No command {" + strings[0] + "} found");
        }

        public static void COMMAND_QUIT(string[] strings, Client client)
        {
            Miscellaneous.server.Disconnect.Enqueue(client);
        }

        public static void COMMAND_SAY(string[] strings, Client client)
        {

            Miscellaneous.server.WriteToAll(buildSay(strings, client));
        }

        private static string buildSay(string[] strings, Client client)
        {
            string output = client.username + " says, \"";
            for (int i = 1; i < strings.Length; i++)
            {
                output += strings[i] + ((i < (strings.Length - 1)) ? " " : "");
            }
            output += "\"" + client.EndLine;

            return output;
        }
    }
}
