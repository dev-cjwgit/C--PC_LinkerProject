using PCLinker.ViewModel.config;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;

namespace PCLinker.ViewModel.controls
{
    public class IconEditWindowViewModel : NotifyPropertyChanged
    {
        public IconEditWindowViewModel()
        {
            DialogCommand = new Command(Dialog, null);
            IconEditWindowVisibility = false;
        }

        #region Command
        private void Dialog(object obj)
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "Icon File (*.ico) | *.ico;";

            if (dlgOpenFile.ShowDialog().ToString() == "OK")
            {
                IconPathText = dlgOpenFile.FileName;
            }
        }

        #endregion

        #region Proerty
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
                if (!value)
                {
                    IconPathText = "";
                }
                OnPropertyChanged(nameof(IconEditWindowVisibility));
            }
        }

        private string _iconPathText;
        public string IconPathText
        {
            get
            {
                return _iconPathText;
            }
            set
            {
                Console.WriteLine(value);
                _iconPathText = value;
                OnPropertyChanged(nameof(IconPathText));
            }
        }

        #endregion

        #region ICommand
        public ICommand DialogCommand { get; set; }

        #endregion
        
    }
}
