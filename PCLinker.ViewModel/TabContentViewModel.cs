using PCLinkerProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCLinker.ViewModel
{
    public class TabContentViewModel : NotifyPropertyChanged
    {
        private int _uid;
        private string _contentIcon;
        private string _contentText;
        private string _programPath;
        private string _command;

        public int Uid
        {
            get
            {
                return _uid;
            }
            set
            {
                _uid = value;
            }
        }

        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }
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
