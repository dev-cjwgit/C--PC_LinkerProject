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
        private static List<ObservableCollection<TabContentViewModel>> contentInstance;


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
            contentInstance = new List<ObservableCollection<TabContentViewModel>>();

            for (int i = 0; i < 2; i++)
            {
                var temp = new ObservableCollection<TabContentViewModel>();

                for (int j = 0; j < 150; j++) {
                    temp.Add(new TabContentViewModel()
                    {
                        ContentIcon = Environment.CurrentDirectory + @"\ICO\content\kakaotalk.ico",
                        ContentText = "VMWare WorkStation" + i + "-" + j
                    }
                    );
                }
                contentInstance.Add(temp);
            }

            Tabs = new ObservableCollection<TabItem>();
            Tabs.Add(new TabItem { HeaderIcon = Environment.CurrentDirectory + @"\ICO\header\Computer.ico", HeaderText = "게임", Content = contentInstance[0] });
            Tabs.Add(new TabItem { HeaderIcon = Environment.CurrentDirectory + @"\ICO\header\Editor.ico", HeaderText = "유틸리티", Content = contentInstance[1] });
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
