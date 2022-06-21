using Evie.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evie.MVVM.ViewModel
{
    class GlobalViewModel : ObservableObject
    {
        public static GlobalViewModel Instance { get; private set; } = new GlobalViewModel();
        public ObservableCollection<string> Logs { get; private set; } = new ObservableCollection<string>();

        public static void AddLog(string msg)
        {
            Instance.Logs.Add(msg);
        }

    }
}
