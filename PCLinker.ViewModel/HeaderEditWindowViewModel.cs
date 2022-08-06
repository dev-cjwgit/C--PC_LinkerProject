using PCLinker.ViewModel.config;
using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class HeaderEditWindowViewModel : NotifyPropertyChanged
    {
        public Func<HeaderDTO, int> callBack;
        public HeaderEditWindowViewModel()
        {
            AcceptButtonCommand = new Command(AcceptButton, null);
        }


        #region Command Method

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

        #endregion
    }
}
