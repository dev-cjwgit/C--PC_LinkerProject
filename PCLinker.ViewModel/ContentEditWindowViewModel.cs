using PCLinker.BusinessModel.interfaces;
using PCLinker.ViewModel.config;
using PCLinker.ViewModel.controls;
using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class ContentEditWindowViewModel : NotifyPropertyChanged
    {
        private IDatabaseManager db;

        public Func<ContentDTO, int> callBack;

        public ContentEditWindowViewModel()
        {
            AcceptButtonCommand = new Command(AcceptButton, null);

            CreateContentCommand = new Command(CreateContent, null);
            UpdateContentCommand = new Command(UpdateContent, null);
            DeleteContentCommand = new Command(DeleteContent, null);

            ContentStartCommand = new Command(ContentStart, null);
        }

        #region Command Method
        private void CreateContent(object obj)
        {
            ContentEditWindowVisibility = true;

            callBack = (contentDTO) =>
            {
                Console.WriteLine("");
                //if (db.CreateContent(SelectedHeaderItem.HeaderText, contentDTO.Title, contentDTO.IconPath, contentDTO.ShellPath, contentDTO.Command))
                //{
                //    SelectedHeaderItem.Content.Add(new TabContentListViewModel()
                //    {
                //        Uid = 0,
                //        ContentIcon = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + contentDTO.IconPath,
                //        ContentText = contentDTO.Title,
                //        ProgramPath = contentDTO.ShellPath,
                //        Args = contentDTO.Command
                //    });

                //}
                return 1;
            };
            Console.WriteLine("컨텐츠 생성");
        }

        private void UpdateContent(object obj)
        {
            if (SelectedContentItem != null)
            {
                ContentEditWindowVisibility = true;

                IconPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + SelectedContentItem.ContentIcon;
                Title = SelectedContentItem.ContentText;
                ShellPath = SelectedContentItem.ProgramPath;
                CommandText = SelectedContentItem.Args;

                //ContentEditWindowDataContext.callBack = (contentDTO) =>
                //{

                //    if (db.UpdateContent(SelectedHeaderItem.HeaderText, SelectedContentItem.ContentText, contentDTO.Title, contentDTO.IconPath, contentDTO.ShellPath, contentDTO.Command))
                //    {
                //        SelectedContentItem.ContentIcon = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + contentDTO.IconPath;
                //        SelectedContentItem.ContentText = contentDTO.Title;
                //        SelectedContentItem.ProgramPath = contentDTO.ShellPath;
                //        SelectedContentItem.Args = contentDTO.Command;
                //    }
                //    return 1;
                //};
            }
            Console.WriteLine("컨텐츠 수정");
        }

        private void DeleteContent(object obj)
        {
            //if (db.DeleteContent(SelectedHeaderItem.HeaderText, SelectedContentItem.ContentText))
            //{
            //    SelectedHeaderItem.Content.Remove(SelectedContentItem);
            //}
        }

        private void ContentStart(object obj)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = SelectedContentItem.ProgramPath;
            startInfo.Arguments = SelectedContentItem.Args;
            Process.Start(startInfo);
            //db.CreateHistory(SelectedHeaderItem.HeaderText, SelectedContentItem.ContentText);
        }
        private void AcceptButton(object obj)
        {
            if (callBack != null)
            {
                string[] dir = IconPath.Split('\\');
                callBack(new ContentDTO()
                {
                    Uid = 0,
                    IconPath = dir[dir.Length - 1],
                    Title = Title,
                    ShellPath = ShellPath,
                    Command = CommandText
                });
            }
            ContentEditWindowVisibility = false;
        }

        #endregion

        #region VM Property
        public TabContentListViewModel SelectedContentItem { get; set; }


        private string _iconPath;
        public string IconPath
        {
            get { return _iconPath; }
            set
            {
                _iconPath = value;
                OnPropertyChanged(nameof(IconPath));
            }

        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }

        }

        private string _shellPath;
        public string ShellPath
        {
            get { return _shellPath; }
            set
            {
                _shellPath = value;
                OnPropertyChanged(nameof(ShellPath));
            }

        }

        private string _commandText;
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                _commandText = value;
                OnPropertyChanged(nameof(CommandText));
            }

        }

        private bool _contentEditWindowVisibility = false;
        public bool ContentEditWindowVisibility
        {
            get
            {
                return _contentEditWindowVisibility;
            }
            set
            {
                _contentEditWindowVisibility = value;
                if (!value)
                {
                    IconPath = "";
                    Title = "";
                    ShellPath = "";
                    CommandText = "";
                }
                OnPropertyChanged(nameof(ContentEditWindowVisibility));
            }
        }
        #endregion


        #region VM ICommand

        public ICommand AcceptButtonCommand { get; set; }

        public ICommand CreateContentCommand { get; private set; }
        public ICommand UpdateContentCommand { get; private set; }
        public ICommand DeleteContentCommand { get; private set; }

        public ICommand ContentStartCommand { get; private set; }
        #endregion
    }
}
