using SQLiteComponent;
using System;
using System.Collections.ObjectModel;

namespace PCLinker.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<HeaderItem>();

            PCLinkerDB.GetInstance();

            var data = PCLinkerDB.GetInstance().GetHeaderList();
            foreach (var item in data)
            {
                var temp = new ObservableCollection<TabContentViewModel>();
                Tabs.Add(new HeaderItem()
                {
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + item.IconPath ,
                    HeaderText = item.Title,
                    Content = temp
                });
            }
        }
        public ObservableCollection<HeaderItem> Tabs { get; set; }
    }
}
