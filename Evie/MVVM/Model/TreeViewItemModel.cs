using System.Collections.ObjectModel;

namespace Evie.MVVM.Model
{
    internal class TreeViewItemModel
    {
        public string Title { get; set; }
        public ObservableCollection<TabItemModel> SubItems { get; set; }
    }
}