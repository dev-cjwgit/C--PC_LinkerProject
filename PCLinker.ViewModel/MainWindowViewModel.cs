﻿using PCLinker.BusinessModel;
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
            Tabs = new ObservableCollection<TabControlHeaderListViewModel>();

            CreateHeaderCommand = new Command(CreateHeader, null);
            UpdateHeaderCommand = new Command(UpdateHeader, null);
            DeleteHeaderCommand = new Command(DeleteHeader, null);

            CreateContentCommand = new Command(CreateContent, null);
            UpdateContentCommand = new Command(UpdateContent, null);
            DeleteContentCommand = new Command(DeleteContent, null);

            ContentStartCommand = new Command(ContentStart, null);

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
                        ContentIcon = Environment.CurrentDirectory + @"\ICO\" + contentItem.IconPath,
                        ProgramPath = contentItem.ShellPath,
                        Args = contentItem.Command
                    });
                }




                Tabs.Add(new TabControlHeaderListViewModel()
                {
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerItem.IconPath,
                    HeaderText = headerItem.Title,
                    Content = temp
                });
            }
        }

        #region VM Command Method

        private void CreateHeader(object obj)
        {
            HeaderEditWindowDataContext.HeaderEditWindowVisibility = true;

            HeaderEditWindowDataContext.callBack = (headerDTO) =>
            {
                if (db.CreateHeader(headerDTO.Title, headerDTO.IconPath))
                {
                    Tabs.Add(new TabControlHeaderListViewModel()
                    {
                        HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerDTO.IconPath,
                        HeaderText = headerDTO.Title,
                        Content = new ObservableCollection<TabContentListViewModel>()
                    });
                }
                return 1;
            };
        }

        private void UpdateHeader(object obj)
        {
            if (SelectedHeaderItem != null)
            {
                HeaderEditWindowDataContext.HeaderEditWindowVisibility = true;

                HeaderEditWindowDataContext.IconPath = Environment.CurrentDirectory + @"\ICO\" + SelectedHeaderItem.HeaderIcon;
                HeaderEditWindowDataContext.Title = SelectedHeaderItem.HeaderText;

                HeaderEditWindowDataContext.callBack = (headerDTO) =>
                {
                    if (db.UpdateHeader(SelectedHeaderItem.HeaderText, headerDTO.Title, headerDTO.IconPath))
                    {
                        SelectedHeaderItem.HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerDTO.IconPath;
                        SelectedHeaderItem.HeaderText = headerDTO.Title;
                    }
                    return 1;
                };
            }
            Console.WriteLine("헤더 수정");
        }

        private void DeleteHeader(object obj)
        {
            if (db.DeleteHeader(SelectedHeaderItem.HeaderText))
            {
                Tabs.Remove(SelectedHeaderItem);
            }
        }

        private void CreateContent(object obj)
        {
            ContentEditWindowDataContext.ContentEditWindowVisibility = true;

            ContentEditWindowDataContext.callBack = (contentDTO) =>
            {
                if (db.CreateContent(SelectedHeaderItem.HeaderText, contentDTO.Title, contentDTO.IconPath, contentDTO.ShellPath, contentDTO.Command))
                {
                    SelectedHeaderItem.Content.Add(new TabContentListViewModel()
                    {
                        Uid = 0,
                        ContentIcon = Environment.CurrentDirectory + @"\ICO\" + contentDTO.IconPath,
                        ContentText = contentDTO.Title,
                        ProgramPath = contentDTO.ShellPath,
                        Args = contentDTO.Command
                    });

                }
                return 1;
            };
            Console.WriteLine("컨텐츠 생성");
        }

        private void UpdateContent(object obj)
        {
            Console.WriteLine("컨텐츠 수정");
        }

        private void DeleteContent(object obj)
        {
            if(db.DeleteContent(SelectedHeaderItem.HeaderText, SelectedContentItem.ContentText))
            {
                SelectedHeaderItem.Content.Remove(SelectedContentItem);
            }
        }

        private void ContentStart(object obj)
        {
            Console.WriteLine(SelectedContentItem.ContentText + " 컨텐츠 시작");
        }

        #endregion

        #region VM Property
        public HeaderEditWindowViewModel HeaderEditWindowDataContext { get; set; } = new HeaderEditWindowViewModel();
        public ContentEditWindowViewModel ContentEditWindowDataContext { get; set; } = new ContentEditWindowViewModel();
        public IconEditWindowViewModel IconEditWindowDataContext { get; set; } = new IconEditWindowViewModel();
        public TabControlHeaderListViewModel SelectedHeaderItem { get; set; }

        public TabContentListViewModel SelectedContentItem { get; set; }

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

        public ObservableCollection<TabControlHeaderListViewModel> Tabs { get; set; }
    }
}
