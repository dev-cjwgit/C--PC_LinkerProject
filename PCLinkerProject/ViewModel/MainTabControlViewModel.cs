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
        private static ObservableCollection<ObservableCollection<TabContentViewModel>> contentInstance;


        public static ObservableCollection<TabContentViewModel> getInstance(int index)
        {
            return contentInstance[index];
        }

        public static MainTabControlViewModel getInstance()
        {
            if (instance == null)
                instance = new MainTabControlViewModel();
            return instance;
        }
        public ObservableCollection<TabItem> Tabs { get; set; }
        public MainTabControlViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            contentInstance = new ObservableCollection<ObservableCollection<TabContentViewModel>>();

            for (int i = 0; i < 20; i++)
            {
                var temp = new ObservableCollection<TabContentViewModel>();

                for (int j = 0; j < 50; j++)
                {
                    temp.Add(new TabContentViewModel()
                    {
                        ContentIcon = Environment.CurrentDirectory + @"\ICO\content\kakaotalk.ico",
                        ContentText = "비주얼" + i + "-" + j
                    }
                    );
                }
                contentInstance.Add(temp);
            }

            for (int i = 0; i < 5; i++)
            {
                Tabs.Add(new TabItem { HeaderIcon = Environment.CurrentDirectory + @"\ICO\header\Computer.ico", HeaderText = "게임" + i, Content = contentInstance[i] });

            }
            //addTab("Computer.ico", "게임");
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

            contentInstance.Add(temp);
            
        }

        public void addContent(int tab_idx, string headerIcon, string headerText)
        {
            contentInstance[tab_idx].Add(new TabContentViewModel()
            {
                ContentIcon = Environment.CurrentDirectory + @"\ICO\content\" + headerIcon,
                ContentText = headerText
            });
        }

        public void deleteTab(int tab_idx)
        {
            contentInstance.RemoveAt(tab_idx);
            Tabs.RemoveAt(tab_idx);
        }

        public void deleteContent(int tab_idx, int content_idx)
        {
            contentInstance[tab_idx].RemoveAt(content_idx);
            
        }
    }

    public sealed class TabItem
    {
        public string HeaderIcon { get; set; }
        public string HeaderText { get; set; }

        public ObservableCollection<TabContentViewModel> Content { get; set; }
        //public ObservableCollection<TabContentViewModel> Content { get; set; }
    }
}
