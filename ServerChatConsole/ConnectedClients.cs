using ClientServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerChatConsole
{
    public class ConnectedClients
    {
        //Make an instance of the callback function vis its contract
        public IClientContract connected;

        public string Username { get; set; }
    }
}
