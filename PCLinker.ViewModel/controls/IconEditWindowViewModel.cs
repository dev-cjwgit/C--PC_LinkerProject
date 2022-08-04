using PCLinker.ViewModel.config;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PCLinker.ViewModel.controls
{
    public class IconEditWindowViewModel : NotifyPropertyChanged
    {
        public IconEditWindowViewModel()
        {
            DialogCommand = new Command(Dialog, null);
            IconEditWindowVisibility = false;
        }

        private void Dialog(object obj)
        {

        }

        private Boolean _iconEditWindowVisibility = false;
        public Boolean IconEditWindowVisibility
        {
            get
            {
                return _iconEditWindowVisibility;
            }
            set
            {
                _iconEditWindowVisibility = value;
                OnPropertyChanged(nameof(IconEditWindowVisibility));
            }
        }

        public ICommand DialogCommand { get; set; }

        private string _iconPathText;
        public string IconPathText
        {
            get
            {
                return _iconPathText;
            }
            set
            {
                _iconPathText = value;
                OnPropertyChanged(nameof(IconPathText));
            }
        }
    }
}
