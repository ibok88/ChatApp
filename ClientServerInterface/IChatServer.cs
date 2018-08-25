using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientServerInterface
{
    //In the service contract, pass the Callback Contract to the clientcallbcak contract class
    [ServiceContract(CallbackContract=typeof(IClientContract))]
    public interface IChatServer
    {   
        [OperationContract]
        int LogIn(string username);

        [OperationContract]

        void SendMessage(string message, string username);
        

    }
}
