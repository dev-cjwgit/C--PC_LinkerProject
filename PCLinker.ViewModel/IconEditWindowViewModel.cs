using PCLinker.ViewModel.config;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PCLinker.ViewModel.controls;
using System.IO;

namespace PCLinker.ViewModel
{
    public class IconEditWindowViewModel : NotifyPropertyChanged
    {
        public IconEditWindowViewModel()
        {
            IconEditWindowVisibility = false;


            IconListSource = new ObservableCollection<IconEditListViewModel>();
            string[] path = Directory.GetFiles(Environment.CurrentDirectory + @"\ICO\", "*.ico");

            foreach(string item in path)
            {

                string[] dir = item.Split('\\');
                IconListSource.Add(new IconEditListViewModel()
                {
                    IconPath = item,
                    Title = dir[dir.Length - 1]
                });
            }
            
        }

        #region Command

        #endregion

        #region Proerty
        private ObservableCollection<IconEditListViewModel> _iconListSource;
        public ObservableCollection<IconEditListViewModel> IconListSource
        {
            get
            {
                return _iconListSource;
            }
            set
            {

                _iconListSource = value;
                OnPropertyChanged(nameof(IconListSource));
            }
        }

        public IconEditListViewModel IconSelectedItem { get; set; }


        private bool _iconEditWindowVisibility = false;
        public bool IconEditWindowVisibility
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
