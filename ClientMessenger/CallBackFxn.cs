using ClientServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientMessenger
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CallBackFxn : IClientContract
    {
        public void GetMessage(string message, string username)
        {
            //Casting to main window to access the main window
            ((MainWindow)Application.Current.MainWindow).TakeMessage(message, username);

        }
    }
}
