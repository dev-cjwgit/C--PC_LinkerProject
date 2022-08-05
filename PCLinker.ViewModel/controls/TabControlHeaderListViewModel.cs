using PCLinker.ViewModel.config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PCLinker.ViewModel.controls
{
    public sealed class TabControlHeaderListViewModel : NotifyPropertyChanged
    {

        private string _headerIcon;

        private string _headerText;

        public string HeaderIcon
        {
            get
            {
                return _headerIcon;
            }

            set
            {
                _headerIcon = value;
                OnPropertyChanged("HeaderIcon");
            }
        }
        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
                OnPropertyChanged("HeaderText");
            }
        }

        public ObservableCollection<TabContentListViewModel> Content { get; set; }
    }
}
