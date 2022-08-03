using PCLinkerProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLinkerProject.VMs
{
    public class IconEditViewModel : NotifyPropertyChanged
    {
        public IconEditViewModel()
        {
            Tabs = new ObservableCollection<HeaderItem>();
        }
        private static IconEditViewModel instance;
        public static IconEditViewModel GetInstance()
        {
            if (instance == null)
            {

                instance = new IconEditViewModel();
            }
            return instance;
        }
        public ObservableCollection<HeaderItem> Tabs { get; set; }



    }
    public sealed class HeaderItem : NotifyPropertyChanged
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
    }
}
