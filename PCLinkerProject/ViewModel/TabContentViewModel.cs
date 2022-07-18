using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLinkerProject.ViewModel
{
    public class TabContentViewModel : NotifyPropertyChanged
    {
        private string _contentIcon;
        private string _contentText;
        private string _programPath;

        public string ContentIcon
        {
            get
            {
                return _contentIcon;
            }
            set
            {
                _contentIcon = value;
                OnPropertyChanged("ContentIcon");
            }
        }

        public string ContentText
        {
            get
            {
                return _contentText;
            }
            set
            {
                _contentText = value;
                OnPropertyChanged("ContentText");
            }
        }

        public string ProgramPath
        {
            get
            {
                return _programPath;
            }
            set
            {
                _programPath = value;
                OnPropertyChanged("ProgramPath");
            }
        }


    }
}
