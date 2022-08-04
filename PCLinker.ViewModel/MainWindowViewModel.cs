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
            CreateHeaderCommand = new Command(CreateHeader, null);
            UpdateHeaderCommand = new Command(UpdateHeader, null);
            DeleteHeaderCommand = new Command(DeleteHeader, null);

            CreateContentCommand = new Command(CreateContent, null);
            UpdateContentCommand = new Command(UpdateContent, null);
            DeleteContentCommand = new Command(DeleteContent, null);

            db = new DatabaseManager();

            foreach(var item in db.GetHeaderList())
            {
                var temp = new ObservableCollection<TabContentViewModel>();
                temp.Add(new TabContentViewModel()
                {
                    ContentIcon = Environment.CurrentDirectory + @"\ICO\computer.ico",
                    ContentText = "김치찌개"
                });
                Tabs.Add(new TabControlHeaderViewModel()
                {
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + item.IconPath,
                    HeaderText = item.Title,
                    Content = temp
                });
            }
        }

        private void CreateHeader(object obj)
        {
            Console.WriteLine("헤더 추가");
        }

        private void UpdateHeader(object obj)
        {
            Console.WriteLine("헤더 수정");
        }

        private void DeleteHeader(object obj)
        {
            Console.WriteLine("헤더 삭제");
        }

        private void CreateContent(object obj)
        {
            Console.WriteLine("컨텐츠 생성");
        }

        private void UpdateContent(object obj)
        {
            Console.WriteLine("컨텐츠 수정");
        }

        private void DeleteContent(object obj)
        {
            Console.WriteLine("컨텐츠 삭제");
        }

        public TabControlHeaderViewModel SelectedHeaderItem { get; set; }

        public TabContentViewModel SelectedContentItem { get; set; }
        public ICommand CreateHeaderCommand { get; private set; }
        public ICommand UpdateHeaderCommand { get; private set; }
        public ICommand DeleteHeaderCommand { get; private set; }

        public ICommand CreateContentCommand { get; private set; }
        public ICommand UpdateContentCommand { get; private set; }
        public ICommand DeleteContentCommand { get; private set; }

        public ObservableCollection<TabControlHeaderViewModel> Tabs { get; set; }
    }
}
