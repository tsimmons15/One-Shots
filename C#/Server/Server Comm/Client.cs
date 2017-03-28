using MudServer.Server_Comm;
using System;
using System.Net.Sockets;

namespace MudServer
{
    public class Client
    {
        public string username = String.Empty;
        private string password = String.Empty;
        private NetworkStream stream = null;
        private TcpClient conn = null;

        private byte[] InputBuffer;
        private string input;
        private byte[] OutputBuffer;
        private string output;

        public string EndLine = "\r\n";

        public bool LoggedIn { get; set; } = false;
        public bool WillDisconnect { get; set; } = false;
        
        public Client(TcpClient client)
        {
            conn = client;
            this.stream = conn.GetStream();
            Server.HasConnections = true;
        }

        public bool CheckForData()
        {
            return this.stream.DataAvailable;
        }

        public void DisconnectUser()
        {
            if (conn != null)
            {
                conn.Client.BeginDisconnect(false, finishDisconnect, null);
            }
        }

        public int Read()
        {
            if (stream == null)
                return -1;

            InputBuffer = new byte[Server.MAX_IO];

            int readLength = stream.Read(InputBuffer, 0, Server.MAX_IO);
            readLength = (readLength < Server.MAX_IO) ? readLength : Server.MAX_IO;

            for (int i = 0; i < readLength; i++)
            {
                if (InputBuffer[i] == 0)
                    break;
                input += (char)InputBuffer[i];
            }

            InputBuffer = null;

            input = input.Trim();

            if (input != String.Empty)
                Client.ParseInput(input, this);

            input = String.Empty;

            return readLength;
        }

        public int Write(byte[] Output)
        {
            if (stream == null)
                return -1;

            stream.Write(Output, 0, (Output.Length < Server.MAX_IO) ? Output.Length : Server.MAX_IO);

            return 0;
        }

        private bool SetUsername(string username)
        {
            if (Miscellaneous.server.UserExists(username))
                return false;
            
            this.username = username;
            this.Write(Miscellaneous.StringToBytes("Welcome, " + this.username + this.EndLine));
            Console.WriteLine(this.username + " logged in");
            this.LoggedIn = true;

            return true;
        }

        private void finishDisconnect(IAsyncResult ar)
        {
            conn.Client.EndDisconnect(ar);

            if (stream != null)
                stream.Close();

            conn.Close();
        }

        public static bool ParseInput(string input, Client client)
        {
            bool ret = false;
            string[] command = input.Split(' ');

            Action<string[], Client> action;
            bool commandFound = ClientCommands.Lookup.TryGetValue(command[0], out action);

            if (!client.LoggedIn)
            //If they are not currently logged in, prompt them to log in before being able to do anything
            {
                LoginCallback(client, command, commandFound);
                return false;
            }
            else
            {

                if (commandFound) //Find the associated action; execute it if found
                {
                    //Call the returned action
                    action(command, client);
                    ret = true;
                }
                else
                {
                    ClientCommands.COMMAND_NOT_FOUND(command, client);
                }

            }
            return ret;
        }

        public static void LoginCallback(Client client, string[] command, bool commandFound)
        {
            ///*
            ///*  Three things can happen:
            ///*  1) They enter a character name, new or otherwise
            ///*  -  The true meat of the program, this will cause the computer to check for an already existing username
            ///*     -  If the username exists, attempt a login (if not already logged in...)
            ///*     -  If the username does not exist, begin character creation
            ///*  2) They enter quit, which should cause the connection to abort
            ///*  -  Connection will not abort immediately - Set quit-flag and then return
            ///*  3) They enter a command, which should be ignored/cause the prompt to redisplay
            ///*  -  Once prompt is redisplayed, return
            ///*
            
            if (commandFound && command[0] != "quit") //3
            {
                string loginPrompt = "Please log in first." + client.EndLine +
                                     "Enter an existing character name, to login" + client.EndLine +
                                     "Or enter a new name to create a new character" + client.EndLine;


                client.Write(Miscellaneous.StringToBytes(loginPrompt));
            }
            else if (command[0] == "quit") //2
            {
                Miscellaneous.server.Disconnect.Enqueue(client);
            }
            else //1
            {
                if (!client.SetUsername(command[0]))
                {
                    client.Write(Miscellaneous.StringToBytes("Name {" + command[0] + "} is already taken." + client.EndLine));
                }
            }
        }
    }
}
