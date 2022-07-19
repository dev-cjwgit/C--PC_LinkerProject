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

            //for (int i = 0; i < 20; i++)
            //{
            //    var temp = new ObservableCollection<TabContentViewModel>();

            //    for (int j = 0; j < 50; j++)
            //    {
            //        temp.Add(new TabContentViewModel()
            //        {
            //            ContentIcon = Environment.CurrentDirectory + @"\ICO\content\kakaotalk.ico",
            //            ContentText = "비주얼" + i + "-" + j
            //        }
            //        );
            //    }
            //    contentInstance.Add(temp);
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Tabs.Add(new TabItem { HeaderIcon = Environment.CurrentDirectory + @"\ICO\header\Computer.ico", HeaderText = "게임" + i, Content = contentInstance[i] });

            //}
            addTab("Computer.ico", "게임");
            //addTab("Computer.ico", "유틸리티");
        }

        public void addTab(string headerIcon, string headerText)
        {
            var temp = new ObservableCollection<TabContentViewModel>();
            Tabs.Add(new TabItem
            {
                HeaderIcon = Environment.CurrentDirectory + @"\ICO\header\" + headerIcon,
                HeaderText = headerText,
                Content = temp,
            });

            
        }

        public void updateTab(int tab_idx, string headerIcon, string headerText)
        {

            Tabs[tab_idx].HeaderIcon = Environment.CurrentDirectory + @"\ICO\header\" + headerIcon;
            Tabs[tab_idx].HeaderText = headerText;

        }
        public void deleteTab(int tab_idx)
        {
            Tabs.RemoveAt(tab_idx);
        }

        public void addContent(int tab_idx, string headerIcon, string headerText, string programPath)
        {
            getInstance(tab_idx).Add(new TabContentViewModel()
            {
                ContentIcon = Environment.CurrentDirectory + @"\ICO\content\" + headerIcon,
                ContentText = headerText,
                ProgramPath = programPath
            });
        }

        public void updateContent(int tab_idx, int content_idx, string headerIcon, string headerText, string programPath)
        {
            getInstance(tab_idx)[content_idx].ContentIcon = Environment.CurrentDirectory + @"\ICO\content\" + headerIcon;
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
        //public ObservableCollection<TabContentViewModel> Content { get; set; }
    }
}
