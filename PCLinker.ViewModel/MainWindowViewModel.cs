using PCLinker.BusinessModel;
using PCLinker.BusinessModel.interfaces;
using PCLinker.ViewModel.config;
using PCLinker.ViewModel.controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        // Commit Test 1
        private IDatabaseManager db;
        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabControlHeaderViewModel>();

            IconEditWindowDataContext = new IconEditWindowViewModel();
            
            CreateHeaderCommand = new Command(CreateHeader, null);
            UpdateHeaderCommand = new Command(UpdateHeader, null);
            DeleteHeaderCommand = new Command(DeleteHeader, null);

            CreateContentCommand = new Command(CreateContent, null);
            UpdateContentCommand = new Command(UpdateContent, null);
            DeleteContentCommand = new Command(DeleteContent, null);

            ContentStartCommand = new Command(ContentStart, null);

            db = new DatabaseManager();

            foreach (var item in db.GetHeaderList())
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

        #region VM Command Method

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

        private void ContentStart(object obj)
        {
            Console.WriteLine("dd");
        }

        #endregion

        #region VM Property
        public IconEditWindowViewModel IconEditWindowDataContext { get; set; }
        public TabControlHeaderViewModel SelectedHeaderItem { get; set; }

        public TabContentViewModel SelectedContentItem { get; set; }

        #endregion

        #region VM ICommand

        public ICommand CreateHeaderCommand { get; private set; }
        public ICommand UpdateHeaderCommand { get; private set; }
        public ICommand DeleteHeaderCommand { get; private set; }

        public ICommand CreateContentCommand { get; private set; }
        public ICommand UpdateContentCommand { get; private set; }
        public ICommand DeleteContentCommand { get; private set; }

        public ICommand ContentStartCommand { get; private set; }

        #endregion

        public ObservableCollection<TabControlHeaderViewModel> Tabs { get; set; }
    }
}
