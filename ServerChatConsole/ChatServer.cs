using ClientServerInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerChatConsole
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatServer" in both code and config file together.
    public class ChatServer : IChatServer
    {
        //The server has to hold a reference to a dictionary of connected clients for callbacks
        public ConcurrentDictionary<string, ConnectedClients> connectedClients = new ConcurrentDictionary<string, ConnectedClients>();

        public int LogIn(string username)
        {
            foreach (var client in connectedClients)
            {
                if (client.Key.ToLower() == username.ToLower())
                {
                    return 1;
                }
            }
                
             //get current callback clients via the inbuilt Getcallbackchannel method
             var establishConnectedClients = OperationContext.Current.GetCallbackChannel<IClientContract>();

             //ConnectedClient instance
             ConnectedClients _newconnectedClient = new ConnectedClients();
             _newconnectedClient.connected = establishConnectedClients;
             _newconnectedClient.Username = username;

             connectedClients.TryAdd(username, _newconnectedClient);

            return 0;

        }

        public void SendMessage(string message, string username)
        {
           foreach(var client in connectedClients)
            {
                if (client.Key.ToLower() != username.ToLower())
                {
                    client.Value.connected.GetMessage(message, username);

                }

            }
        }
    }
}
