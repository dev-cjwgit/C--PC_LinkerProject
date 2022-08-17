using PCLinker.BusinessModel;
using PCLinker.BusinessModel.interfaces;
using PCLinker.ViewModel.config;
using PCLinker.ViewModel.controls;
using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class HeaderEditWindowViewModel : NotifyPropertyChanged
    {
        private IDatabaseManager db;
        public Func<HeaderDTO, int> callBack;
        public HeaderEditWindowViewModel()
        {
            Tabs = new ObservableCollection<TabControlHeaderListViewModel>();

            AcceptButtonCommand = new Command(AcceptButton, null);

            CreateHeaderCommand = new Command(CreateHeader, null);
            UpdateHeaderCommand = new Command(UpdateHeader, null);
            DeleteHeaderCommand = new Command(DeleteHeader, null);

            db = new DatabaseManager();

            foreach (var headerItem in db.GetHeaderList())
            {
                var temp = new ObservableCollection<TabContentListViewModel>();

                var contentList = db.GetContentList(headerItem.Uid);

                foreach (var contentItem in contentList)
                {
                    temp.Add(new TabContentListViewModel()
                    {
                        Uid = contentItem.Uid,
                        ContentText = contentItem.Title,
                        ContentIcon = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + contentItem.IconPath,
                        ProgramPath = contentItem.ShellPath,
                        Args = contentItem.Command
                    });
                }

                Tabs.Add(new TabControlHeaderListViewModel()
                {
                    HeaderIcon = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + headerItem.IconPath,
                    HeaderText = headerItem.Title,
                    Content = temp
                });
            }

            SelectedHeaderItem = Tabs[0];
        }


        #region Command Method

        private void CreateHeader(object obj)
        {
            HeaderEditWindowVisibility = true;

            callBack = (headerDTO) =>
            {
                if (db.CreateHeader(headerDTO.Title, headerDTO.IconPath))
                {
                    Tabs.Add(new TabControlHeaderListViewModel()
                    {
                        HeaderIcon = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + headerDTO.IconPath,
                        HeaderText = headerDTO.Title,
                        Content = new ObservableCollection<TabContentListViewModel>()
                    });
                }
                return 1;
            };
        }

        private void UpdateHeader(object obj)
        {
            TabControlHeaderListViewModel header = obj as TabControlHeaderListViewModel;
            //if (SelectedHeaderItem != null)

            HeaderEditWindowVisibility = true;
            SelectedHeaderItem = header;
            IconPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + SelectedHeaderItem.HeaderIcon;
            Title = SelectedHeaderItem.HeaderText;

            callBack = (headerDTO) =>
            {
                if (db.UpdateHeader(SelectedHeaderItem.HeaderText, headerDTO.Title, headerDTO.IconPath))
                {
                    SelectedHeaderItem.HeaderIcon = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + headerDTO.IconPath;
                    SelectedHeaderItem.HeaderText = headerDTO.Title;
                }
                return 1;
            };

            Console.WriteLine("헤더 수정");
        }

        private void DeleteHeader(object obj)
        {
            TabControlHeaderListViewModel header = obj as TabControlHeaderListViewModel;

            SelectedHeaderItem = header;

            if (db.DeleteHeader(SelectedHeaderItem.HeaderText))
            {
                Tabs.Remove(SelectedHeaderItem);
            }
        }

        private void AcceptButton(object obj)
        {
            if (callBack != null)
            {
                string[] dir = IconPath.Split('\\');
                callBack(new HeaderDTO()
                {
                    Uid = 0,
                    IconPath = dir[dir.Length - 1],
                    Title = Title
                });
            }
            HeaderEditWindowVisibility = false;
        }

        #endregion

        #region Property
        private TabControlHeaderListViewModel _selectedHeaderItem;
        public TabControlHeaderListViewModel SelectedHeaderItem { 
            get
            {
                return _selectedHeaderItem;
            }

            set
            {
                _selectedHeaderItem = value;
                OnPropertyChanged(nameof(SelectedHeaderItem));
            }
        }


        private bool _headerEditWindowVisibility = false;
        public bool HeaderEditWindowVisibility
        {
            get
            {
                return _headerEditWindowVisibility;
            }
            set
            {
                _headerEditWindowVisibility = value;
                if (!value)
                {
                    IconPath = "";
                    Title = "";
                }
                OnPropertyChanged(nameof(HeaderEditWindowVisibility));
            }
        }


        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _iconPath;
        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                _iconPath = value;
                OnPropertyChanged(nameof(IconPath));
            }
        }
        #endregion

        #region ICommand
        public ICommand AcceptButtonCommand { get; set; }

        public ICommand CreateHeaderCommand { get; private set; }
        public ICommand UpdateHeaderCommand { get; private set; }
        public ICommand DeleteHeaderCommand { get; private set; }
        #endregion

        public ObservableCollection<TabControlHeaderListViewModel> Tabs { get; set; }

    }
}
