using Evie.MVVM.Model;
using System.Windows.Media.Imaging;

namespace Evie.Interfaces
{
    internal interface INetworkService
    {
        ValidationResponse Connect(string IP, int Port, TabItemModel tabItem);
        void Run();
        void ExchangeKeys();
        void VerifyConnection();
        byte ReadOpCode();
        byte[] ReadImage();
    }
}
