using PCLinker.ViewModel.config;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCLinker.ViewModel.controls
{
    public class IconEditListViewModel : NotifyPropertyChanged
    {
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
    }
}
