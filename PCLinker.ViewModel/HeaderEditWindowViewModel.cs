using PCLinker.ViewModel.config;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCLinker.ViewModel
{
    public class HeaderEditWindowViewModel : NotifyPropertyChanged
    {
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
    }
}
