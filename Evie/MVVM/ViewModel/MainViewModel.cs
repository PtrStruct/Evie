using Evie.Interfaces;
using Evie.MVVM.Core;
using Evie.MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace Evie.MVVM.ViewModel
{
    internal class MainViewModel
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;
        public ObservableCollection<TreeViewItemModel> TreeViewItems { get; set; }
        public ObservableCollection<TabItemModel> TabsCollection { get; set; }


        public RelayCommand AddToTabsCommand { get; set; }

        public MainViewModel()
        {
            TreeViewItems = new ObservableCollection<TreeViewItemModel>();
            TabsCollection = new ObservableCollection<TabItemModel>();


            var b = new Random();

            for (int i = 1; i < 10; i++)
            {
                var items = new ObservableCollection<TabItemModel>();
                for (int r = 0; r < i; r++)
                    items.Add(new TabItemModel
                    {
                        Title = $"Item {r}",
                        Description = $"Test {b.Next(5000, 10000)}",
                        IP = "127.0.0.1",
                        Port = 1313
                    });

                TreeViewItems.Add(new TreeViewItemModel
                {
                    Title = $"Serverfarm {i}",
                    SubItems = items
                });
            }

            AddToTabsCommand = new RelayCommand(o => AddToTabCollection(o), o => true);
        }

        private void AddToTabCollection(object o)
        {
            var socket = o as TabItemModel;
            if (!TabsCollection.Contains(socket))
            {
                if (socket.Connect())
                {
                    TabsCollection.Add(socket);
                }
            }
        }
    }
}