using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerChatConsole
{
    public class Program
    {
        public static ChatServer _server;
        public static void Main(string[] args)
        {
            _server = new ChatServer();
            using (ServiceHost host = new ServiceHost(_server))
            {
                host.Open();
                Console.WriteLine("The Server is now running...");
                Console.ReadLine();

            }
        }
    }
}
