using PCLinker.ViewModel.config;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PCLinker.ViewModel.controls;
using System.IO;
using PCLinker.BusinessModel;

namespace PCLinker.ViewModel
{
    public delegate void ButtonClickEventHandler();
    public class IconEditWindowViewModel : NotifyPropertyChanged
    {
        public static Func<string, int> callback;


        private static IconEditWindowViewModel instance;
        public static IconEditWindowViewModel GetInstance(Func<string, int> func)
        {
            if (instance == null)
                instance = new IconEditWindowViewModel();
            callback = func;
            return instance;
        }

        private IconEditManager iconEditManager;
        public IconEditWindowViewModel()
        {
            iconEditManager = new IconEditManager();

            IconAddButtonCommand = new Command(IconAddButton, null);
            IconDeleteButtonCommand = new Command(IconDeleteButton, null);

            //SelectIconCommand = new Command(SelectIconButton, null);

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
            instance = this;
        }

        #region Command Method
        private void IconAddButton(object obj)
        {
            if (iconEditManager.CopyIcon(IconPathText))
            {
                String[] dir = IconPathText.Split('\\');
                string fileName = dir[dir.Length - 1];

                IconListSource.Add(new IconEditListViewModel()
                {
                    IconPath = IconPathText,
                    Title = fileName
                });
                IconPathText = "";
            }
        }

        private void IconDeleteButton(object obj)
        {
            //MessageBox.Show("지원하지 않는 기능입니다.");
            //if (IconSelectedItem != null)
            //{
            //    var temp = IconSelectedItem;
            //    IconListSource.Remove(IconSelectedItem);
            //    if (!iconEditManager.DeleteIcon(temp.IconPath))
            //    {
            //        IconListSource.Add(temp);
            //    }
            //}
        }

        //private void SelectIconButton(object obj)
        //{
        //    callback(IconPathText);
        //}
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
                    callback = null;
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

        public ICommand IconAddButtonCommand { get; set; }

        public ICommand IconDeleteButtonCommand { get; set; }

        //public ICommand SelectIconCommand { get; set; }
        #endregion

    }
}
