using Evie.MVVM.Core;
using Evie.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Evie.MVVM.ViewModel
{
    internal class MainViewModel
    {
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
                        Description = $"Test {b.Next(5000, 10000)}"
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
            var item = o as TabItemModel;
            if (!TabsCollection.Contains(item))
                TabsCollection.Add(item);
        }
    }
}