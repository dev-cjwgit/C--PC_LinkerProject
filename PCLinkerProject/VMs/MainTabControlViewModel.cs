using SQLiteComponent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLinkerProject.ViewModel
{
    public sealed class MainTabControlViewModel
    {
        private static MainTabControlViewModel instance;
        public ObservableCollection<TabItem> Tabs { get; set; }


        public ObservableCollection<TabContentViewModel> getInstance(int index)
        {
            return Tabs[index].Content;
        }

        public static MainTabControlViewModel getInstance()
        {
            if (instance == null)
                instance = new MainTabControlViewModel();
            return instance;
        }
        public MainTabControlViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();

            var data = PCLinkerDB.GetInstance().GetHeaderList();

            Console.WriteLine();


        }

        public void addTab(string headerIcon, string headerText)
        {
            if (PCLinkerDB.GetInstance().AddHeader(headerText, headerIcon))
            {
                var temp = new ObservableCollection<TabContentViewModel>();
                int uid = PCLinkerDB.GetInstance().getHeaderUidByTitle(headerText);
                Tabs.Add(new TabItem
                {
                    Uid = uid,
                    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerIcon,
                    HeaderText = headerText,
                    Content = temp,
                });
            }

        }

        public void updateTab(int tab_idx, string headerIcon, string headerText)
        {
            long tab_uid = Tabs[tab_idx].Uid;
            if (PCLinkerDB.GetInstance().UpdateHeader(tab_uid, headerText, headerIcon))
            {
                Tabs[tab_idx].HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerIcon;
                Tabs[tab_idx].HeaderText = headerText;
            }

        }
        public void deleteTab(int tab_idx)
        {
            long tab_uid = Tabs[tab_idx].Uid;
            try
            {
                PCLinkerDB.GetInstance().DeleteHeader(tab_uid);
                Tabs.RemoveAt(tab_idx);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void addContent(int tab_idx, string headerIcon, string headerText, string programPath)
        {
            getInstance(tab_idx).Add(new TabContentViewModel()
            {
                ContentIcon = Environment.CurrentDirectory + @"\ICO\" + headerIcon,
                ContentText = headerText,
                ProgramPath = programPath
            });
        }

        public void updateContent(int tab_idx, int content_idx, string headerIcon, string headerText, string programPath)
        {
            getInstance(tab_idx)[content_idx].ContentIcon = Environment.CurrentDirectory + @"\ICO\" + headerIcon;
            getInstance(tab_idx)[content_idx].ContentText = headerText;
            getInstance(tab_idx)[content_idx].ProgramPath = programPath;

        }

        public void deleteContent(int tab_idx, int content_idx)
        {
            getInstance(tab_idx).RemoveAt(content_idx);

        }
    }

    public sealed class TabItem : NotifyPropertyChanged
    {
        private long uid;

        private string _headerIcon;

        private string _headerText;

        public long Uid
        {
            get
            {
                return uid;
            }
            set { uid = value; }
        }
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

        public ObservableCollection<TabContentViewModel> Content { get; set; }
        //public ObservableCollection<TabContentViewModel> Content { get; set; }
    }
}
