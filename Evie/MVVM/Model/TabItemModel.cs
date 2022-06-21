using System;
using Evie.MVVM.ViewModel;
using System.Net.Sockets;

namespace Evie.MVVM.Model
{
    internal class TabItemModel
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public TcpClient Client { get; private set; }

        public bool Connect()
        {
            Client = new TcpClient();
            GlobalViewModel.Instance.Logs.Add($"[{DateTime.Now.ToShortTimeString()}] - {Title} - Trying to connect to IP: {IP}:{Port}");
            
            if (string.IsNullOrEmpty(IP) || Port == 0)
            {
                GlobalViewModel.Instance.Logs.Add($"[{DateTime.Now.ToShortTimeString()}] - {Title} - Please enter a valid IP and Port.");
                return false;
            }
            
            try
            {
                Client.Connect(IP, Port);
                /* Perform Handshake */
                return true;
            }
            catch (Exception ex)
            {
                GlobalViewModel.Instance.Logs.Add($"[{DateTime.Now.ToShortTimeString()}] - {Title} - {ex.Message}");
                return false;
            }
        }
    }
}