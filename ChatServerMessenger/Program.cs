using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerMessenger
{
    
    class Program
    {
        public static ChatService serverInstance;
        static void Main(string[]args)
        {

            serverInstance = new ChatService();
            ServiceHost host = new ServiceHost(serverInstance);
            host.Open();
            Console.WriteLine("The Server is now running...");
            Console.ReadLine();

        }
    }
}
