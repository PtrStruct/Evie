using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evie.Interfaces
{
    internal interface IHandshake
    {
        void Connect();
        void ExchangeKeys();
        void VerifyConnection();
        void SendData();
        void ReceiveData();
    }
}
