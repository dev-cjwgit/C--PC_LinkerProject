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

        }

        public void addTab(string headerIcon, string headerText)
        {

            var temp = new ObservableCollection<TabContentViewModel>();
            Tabs.Add(new TabItem
            {
                HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerIcon,
                HeaderText = headerText,
                Content = temp,
            });


        }

        public void updateTab(int tab_idx, string headerIcon, string headerText)
        {
            Tabs[tab_idx].HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + headerIcon;
            Tabs[tab_idx].HeaderText = headerText;
        }
        public void deleteTab(int tab_idx)
        {
            Tabs.RemoveAt(tab_idx);
        }

        public void addContent(int uid, string header_tItle, string title, string icon_path, string shell_path, string command)
        {
            int idx = 0;
            foreach(var data in instance.Tabs)
            {
                if(data.HeaderText == header_tItle)
                {
                    getInstance(idx).Add(new TabContentViewModel()
                    {
                        ContentIcon = Environment.CurrentDirectory + @"\ICO\" + icon_path,
                        ContentText = title,
                        ProgramPath = shell_path,
                        Command = command,
                        Uid = uid
                    });
                    break;
                }
                idx++;
            }
            
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

        public ObservableCollection<TabContentViewModel> Content { get; set; }
    }
}
