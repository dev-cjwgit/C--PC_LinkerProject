<<<<<<< .merge_file_a25916
﻿using PCLinkerProject.ViewModel;
using SQLiteComponent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
=======
﻿using PCLinker.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
>>>>>>> .merge_file_a26948

namespace PCLinkerProject
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
<<<<<<< .merge_file_a25916
        public static PCLinkerDB db;
        public static int selected_tab = -1; // selected tab idx
        public static int selected_content = -1; // selected listbox idx
        private WindowState PrevWindowState = WindowState.Normal;
        public static PresentStatusEnum presentStatus = PresentStatusEnum.None;
        public MainWindow()
        {
            InitializeComponent();
            PCLinkerDB.GetInstance();
            TabControl1.DataContext = MainTabControlViewModel.getInstance();

            var data = PCLinkerDB.GetInstance().GetHeaderList();
            foreach (var item in data)
            {
                MainTabControlViewModel.getInstance().addTab(item.IconPath, item.Title);
            }
            Console.WriteLine();
=======
        //public static PCLinkerDB db;
        public static int selected_tab = -1; // selected tab idx
        public static int selected_content = -1; // selected listbox idx
        private WindowState PrevWindowState = WindowState.Normal;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            //PCLinkerDB.GetInstance();
            //TabControl1.DataContext = MainTabControlViewModel.getInstance();

            //var data = PCLinkerDB.GetInstance().GetHeaderList();
            //foreach (var item in data)
            //{
            //    MainTabControlViewModel.getInstance().addTab(item.IconPath, item.Title);
            //}
>>>>>>> .merge_file_a26948

        }

        #region Windows Events
        private void WindowsTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.33));
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.33));
            anim.Completed += (s, _) =>
            {
                Environment.Exit(0);
            };
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void WindowsCloseButton_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void WindowsMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            PrevWindowState = WindowState;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) =>
            {
                this.WindowState = WindowState.Minimized;
                //TrayInit();

            };

            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void WindowsMaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState temp = (this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
            DoubleAnimation anim1 = new DoubleAnimation(1, 0, (Duration)TimeSpan.FromSeconds(0.33));
            DoubleAnimation anim2 = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.33));

            anim1.Completed += (s, _) =>
            {
                this.WindowState = temp;
                this.BeginAnimation(OpacityProperty, anim2);
            };

            this.BeginAnimation(OpacityProperty, anim1);
        }

        #endregion

        private void Content_StartProgram(object sender, MouseButtonEventArgs e)
        {
<<<<<<< .merge_file_a25916
            dynamic meta_data = sender as dynamic;
            var temp = MainTabControlViewModel.getInstance().getInstance(selected_tab);
            //temp[selected_content].ProgramPath;
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = temp[selected_content].ProgramPath;
            myProcess.Start();
=======
            //dynamic meta_data = sender as dynamic;
            //var temp = MainTabControlViewModel.getInstance().getInstance(selected_tab);
            ////temp[selected_content].ProgramPath;
            //Process myProcess = new Process();
            //myProcess.StartInfo.FileName = temp[selected_content].ProgramPath;
            //myProcess.Start();
>>>>>>> .merge_file_a26948
        }

        private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            Console.WriteLine("Console");
            selected_tab = (sender as System.Windows.Controls.TabControl).SelectedIndex;
=======
            //Console.WriteLine("Console");
            //selected_tab = (sender as System.Windows.Controls.TabControl).SelectedIndex;
>>>>>>> .merge_file_a26948
        }

        private void Content_Selected(object sender, SelectionChangedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            dynamic meta_data = sender as dynamic;
            selected_content = meta_data.SelectedIndex;
=======
            //dynamic meta_data = sender as dynamic;
            //selected_content = meta_data.SelectedIndex;
>>>>>>> .merge_file_a26948

        }

        private void Content_Append(object sender, RoutedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            presentStatus = PresentStatusEnum.AddContent;
            ContentEditWindow.Visibility = Visibility.Visible;
=======
            //presentStatus = PresentStatusEnum.AddContent;
            //ContentEditWindow.Visibility = Visibility.Visible;
>>>>>>> .merge_file_a26948
        }

        private void Content_Update(object sender, RoutedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            presentStatus = PresentStatusEnum.UpdateContent;
            ContentEditWindow.Visibility = Visibility.Visible;
=======
            //presentStatus = PresentStatusEnum.UpdateContent;
            //ContentEditWindow.Visibility = Visibility.Visible;
>>>>>>> .merge_file_a26948
            //var temp = MainTabControlViewModel.getInstance(selected_index);
            //Console.WriteLine("U : " + temp[selected_item_index].ContentText);
        }

        private void Content_Delete(object sender, RoutedEventArgs e)
        {
            // MainTabControlViewModel.getInstance().addContent(selected_index, "PyCharm.ico", textbox1.Text.ToString());
            // MainTabControlViewModel.getInstance().addTab("chrome.ico", textbox1.Text.ToString());
<<<<<<< .merge_file_a25916
            var temp = MainTabControlViewModel.getInstance().getInstance(selected_tab);
            Console.WriteLine("D : " + temp[selected_content].ContentText);

            MainTabControlViewModel.getInstance().deleteContent(selected_tab, selected_content);
=======
            //var temp = MainTabControlViewModel.getInstance().getInstance(selected_tab);
            //Console.WriteLine("D : " + temp[selected_content].ContentText);

            //MainTabControlViewModel.getInstance().deleteContent(selected_tab, selected_content);
>>>>>>> .merge_file_a26948

        }
        private void WindowsConfigButton_Click(object sender, RoutedEventArgs e)
        {
            //
<<<<<<< .merge_file_a25916
            IconEditWindow.Visibility = Visibility.Visible;
=======
            //IconEditWindow.Visibility = Visibility.Visible;
>>>>>>> .merge_file_a26948
        }

        private void Temp_onClick(object sender, MouseButtonEventArgs e)
        {
            //MainTabControlViewModel.getInstance().addTab("back.jpg", "임시1");

            //EditWindow.Visibility = Visibility.Visible;
        }


        private void Header_Append(object sender, RoutedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            presentStatus = PresentStatusEnum.AddTab;
            HeaderEditWindow.Visibility = Visibility.Visible;
=======
            //presentStatus = PresentStatusEnum.AddTab;
            //HeaderEditWindow.Visibility = Visibility.Visible;
>>>>>>> .merge_file_a26948
        }

        private void Header_Update(object sender, RoutedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            presentStatus = PresentStatusEnum.UpdateTab;
            HeaderEditWindow.Visibility = Visibility.Visible;
=======
            //presentStatus = PresentStatusEnum.UpdateTab;
            //HeaderEditWindow.Visibility = Visibility.Visible;
>>>>>>> .merge_file_a26948
        }

        private void Header_Delete(object sender, RoutedEventArgs e)
        {
<<<<<<< .merge_file_a25916
            MainTabControlViewModel.getInstance().deleteTab(selected_tab);
=======
            //MainTabControlViewModel.getInstance().deleteTab(selected_tab);
>>>>>>> .merge_file_a26948
        }

    }
}