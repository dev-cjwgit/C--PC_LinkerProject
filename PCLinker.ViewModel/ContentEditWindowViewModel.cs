using PCLinker.ViewModel.config;
using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class ContentEditWindowViewModel : NotifyPropertyChanged
    {
        public Func<ContentDTO, int> callBack;

        public ContentEditWindowViewModel()
        {
            AcceptButtonCommand = new Command(AcceptButton, null);
        }

        #region Command Method

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

        #endregion
    }
}
