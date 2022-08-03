using PCLinker.BusinessModel;
using PCLinker.BusinessModel.interfaces;
using PCLinker.ViewModel.config;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class MainWindowViewModel
    {
        private IDatabaseManager db;
        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabControlHeaderViewModel>();
            DeleteHeaderCommand = new Command(DeleteHeader, null);
            DeleteContentCommand = new Command(DeleteContent, null);

            db = new DatabaseManager();

            foreach(var item in db.GetHeaderList())
            {
                Tabs.Add(new TabControlHeaderViewModel()
                {
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + item.IconPath,
                    HeaderText = item.Title,
                    Content = new ObservableCollection<TabContentViewModel>()
                });
            }
        }


        private void DeleteHeader(object obj)
        {
            Console.WriteLine("");
        }

        private void DeleteContent(object obj)
        {
            Console.WriteLine("");
        }

        public TabControlHeaderViewModel SelectedHeaderItem { get; set; }

        public TabContentViewModel SelectedContentItem { get; set; }

        public ICommand DeleteHeaderCommand { get; private set; }

        public ICommand DeleteContentCommand { get; private set; }

        public ObservableCollection<TabControlHeaderViewModel> Tabs { get; set; }
    }
}
