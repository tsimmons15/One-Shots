using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudServer
{
    public class Message
    {
        public Client Destination;
        public String Text;

        public Message(Client dest, String text)
        {
            this.Destination = dest;
            this.Text = text;
        }
    }
}
