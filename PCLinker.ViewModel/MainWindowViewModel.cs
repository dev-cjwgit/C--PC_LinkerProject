using PCLinker.ViewModel.config;
using SQLiteComponent;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabControlHeaderViewModel>();
            DeleteHeaderCommand = new Command(DeleteHeader, null);
            DeleteContentCommand = new Command(DeleteContent, null);
            PCLinkerDB.GetInstance();
            
            var data = PCLinkerDB.GetInstance().GetHeaderList();
            foreach (var item in data)
            {
                var temp = new ObservableCollection<TabContentViewModel>();
                temp.Add(new TabContentViewModel()
                {
                    ContentText = "김치찌개1",
                    ContentIcon = Environment.CurrentDirectory + @"\ICO\computer.ico"
                });
                temp.Add(new TabContentViewModel()
                {
                    ContentText = "김치찌개2",
                    ContentIcon = Environment.CurrentDirectory + @"\ICO\computer.ico"
                });

                Tabs.Add(new TabControlHeaderViewModel()
                {
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + item.IconPath ,
                    HeaderText = item.Title,
                    Content = temp
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
