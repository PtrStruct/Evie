using Evie.Interfaces;
using Evie.MVVM.Core;
using Evie.MVVM.Model;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Evie.Networking
{
    class NetworkClient : ObservableObject, INetworkService
    {
        private TcpClient _tcpSocket;
        private TabItemModel _tabItemModel;

        public ValidationResponse Connect(string IP, int Port, TabItemModel tabItemModel)
        {
            _tcpSocket = new TcpClient();
            _tabItemModel = tabItemModel;

            try
            {
                _tcpSocket.Connect(IP, Port);
                return new ValidationResponse { Successful = true, Information = $"Successfully connected to {IP}:{Port}!" };
            }
            catch (Exception ex)
            {
                return new ValidationResponse { Successful = false, Information = ex.Message };
            }
        }

        public void ExchangeKeys()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadImage()
        {
            byte[] buffer;
            var stream = _tcpSocket.GetStream();
            var Length = stream.ReadByte() |
                         stream.ReadByte() << 8 |
                         stream.ReadByte() << 16 |
                         stream.ReadByte() << 24;

            buffer = new byte[Length];
            stream.Read(buffer, 0, Length);
            return buffer;
        }

        public byte ReadOpCode()
        {
            var stream = _tcpSocket.GetStream();
            var OpCode = stream.ReadByte();
            return (byte)OpCode;
        }

        public void Run()
        {
            switch (ReadOpCode())
            {
                case 0x00:
                    _tabItemModel.ImageData = ReadImage();
                    break;
                default:
                    break;
            }
        }

        public void VerifyConnection()
        {
            throw new NotImplementedException();
        }
    }
}