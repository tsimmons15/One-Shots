using MudServer.Server_Comm;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace MudServer
{
    public class Server
    {
        private TcpListener listener;

        public static readonly int MAX_IO = 1000;

        private List<Client> clients;
        public static bool HasConnections { get; set; }
        
        public Queue<Client> Disconnect;

        public bool IsListening { get; set; }

        public Server(string ip = "127.0.0.1", int port = 23, bool exclUse = false)
        {
            listener = new TcpListener(IPAddress.Parse(ip), 23);

            clients = new List<Client>();

            Disconnect = new Queue<Client>();
        }

        public bool StartServer()
        {
            listener.Start();

            this.IsListening = true;

            return this.IsListening;
        }

        public bool StopServer()
        {
            listener.Stop();

            this.IsListening = false;

            return !this.IsListening;
        }

        public bool ParseInput(string input)
        {
            bool ret = false;
            string[] command = input.Split(' ');

            Action<string[]> action;

            //Find the associated action; execute it if found
            if (ServerCommands.Lookup.TryGetValue(command[0], out action))
            {
                //Call the returned action
                action(command);
                ret = true;
            }
            else
            {
                ServerCommands.COMMAND_NOT_FOUND(command);
            }

            return ret;
        }

        public bool ConnectionPending
        {
            get
            {
                return listener.Pending();
            }
        }

        public bool AcceptConnection()
        {
            bool ret = true;

            try
            {
                listener.BeginAcceptTcpClient(finishClientAccept, null);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
        
        public void CloseConnections()
        {
            foreach (Client c in clients)
            {
                c.DisconnectUser();
            }
        }

        public bool UserExists(string username)
        {
            bool ret = false;

            for (int i = 0; i < clients.Count; i++)
            {
                ret |= clients[i].username == username;
            }

            return ret;
        }
        
        public int WriteToClient(int client)
        {
            int writeLength = 0;
            clients[client].Write(Miscellaneous.StringToBytes("Test in WriteToClient?"));
            return writeLength;
        }

        public int WriteToAll(string text)
        {
            int writeLength = 0;

            foreach (Client c in clients)
            {
                //TODO: Uncomment when log-in is finished
                //if (c.LoggedIn)
                    writeLength += c.Write(Miscellaneous.StringToBytes(text));
            }

            return writeLength / clients.Count;
        }

        public bool QueryClients()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].CheckForData())
                {
                    //Queue up to be read.
                    //Or get the data itself?
                    //Look into making the Async reads work
                    clients[i].Read();
                }
            }

            //If there are any clients which quit, disconnect them now
            while (Disconnect.Count > 0)
            {
                Client client = Disconnect.Dequeue();
                client.DisconnectUser();
                Console.WriteLine(client.username + " logged off");
                clients.Remove(client);
            }

            return true;
        }


        private void finishClientAccept(IAsyncResult ar)
        {
            TcpClient client = listener.EndAcceptTcpClient(ar);
            byte[] buff = new byte[Server.MAX_IO];
            Client newClient = new Client(client);
            
            int readLength = client.GetStream().Read(buff, 0, Server.MAX_IO);

            //Login
            newClient.Write(Miscellaneous.StringToBytes("Welcome!" + newClient.EndLine +
                                                        "Enter an existing character name, to login" + newClient.EndLine +
                                                        "Or enter a new name to create a new character" + newClient.EndLine));

            clients.Add(newClient);
        }


    }
}
