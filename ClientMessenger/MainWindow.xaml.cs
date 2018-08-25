using ClientServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientMessenger
{
  
    public partial class MainWindow : Window
    {
        public static IChatServer _serviceContract;
        //Getting in a deuplex channel factory to handle calls in and out 
        public static DuplexChannelFactory<IChatServer> _channelFactory; 
        public MainWindow()
        {
            InitializeComponent();
            //pass the new client callback function created class and endpoint name
            _channelFactory = new DuplexChannelFactory<IChatServer>(new CallBackFxn(), "ChattingServiceEndpoint");
            _serviceContract = _channelFactory.CreateChannel();
        }

        //To Take Message
        public void TakeMessage(string message, string username)
        {
            TxtDisplayTexbox.Text += username + ":" + message + "\n";
            TxtDisplayTexbox.ScrollToEnd();
        }

        private void btnsend_Click(object sender, RoutedEventArgs e)
        {
            if (TxtMsgBox.Text.Length > 0)
            {

            }
            _serviceContract.SendMessage(TxtMsgBox.Text, TxtName.Text);
            TakeMessage(TxtMsgBox.Text, "you");
            TxtMsgBox.Text = "";
            
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            int returnval = _serviceContract.LogIn(TxtName.Text);
            if (returnval == 1)
            {
                MessageBox.Show("User Already exists");
            }
            else if(returnval == 0)
            {
                MessageBox.Show(TxtName.Text + " "+ "Logged in");
                lblWelcomename.Content = "Welcome,"+" "+ TxtName.Text;
                TxtName.IsEnabled = false;
                LogIn.IsEnabled = false;
            }
        }
    }
}
