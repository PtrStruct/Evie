using System;
using System.Threading.Tasks;
using Evie.MVVM.ViewModel;
using Evie.Networking;

namespace Evie.MVVM.Model
{
    internal class TabItemModel : NetworkClient
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        //public byte[] ImageData { get; set; }

        private byte[] _imageData;

        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                _imageData = value;
                OnPropertyChanged();
            }
        }


        public bool Connect()
        {
            GlobalViewModel.AddLog($"[{DateTime.Now.ToShortTimeString()}] - {Title} - Trying to connect to IP: {IP}:{Port}");

            if (string.IsNullOrEmpty(IP) || Port == 0)
            {
                GlobalViewModel.AddLog($"[{DateTime.Now.ToShortTimeString()}] - {Title} - Please enter a valid IP and Port.");
                return false;
            }

            var connection = Connect(IP, Port, this);
            GlobalViewModel.AddLog($"[{DateTime.Now.ToShortTimeString()}] - " + $"{Title} - {connection.Information}");
            if (connection.Successful)
            {
                /* Start receiving data */
                Task.Run(() =>
                {
                    while (true)
                    {
                        Run();
                    }

                });
                return true;
            }

            return false;
        }
    }
}