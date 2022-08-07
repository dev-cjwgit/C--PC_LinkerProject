﻿
using PCLinker.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCLinkerProject.Controls
{
    /// <summary>
    /// EditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContentEditWindow : System.Windows.Controls.UserControl
    {

        public ContentEditWindow()
        {
            InitializeComponent();
        }
        public void recv(String fileName)
        {
            //IconTextbox.Text = fileName;
        }
        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;

        }

        private void AcceptButton_onClick(object sender, RoutedEventArgs e)
        {

            //switch (MainWindow.presentStatus)
            //{
            //    case PresentStatusEnum.None:
            //        {
            //            break;
            //        }

            //    case PresentStatusEnum.AddContent:
            //        {
            //            String[] dir = IconTextbox.Text.ToString().Split('\\');
            //            //MainTabControlViewModel.getInstance().addContent(-1, 
            //            //    MainWindow.selected_tab, dir[dir.Length - 1], TitleTextbox.Text.ToString(), ShellTextbox.Text.ToString());
            //            break;
            //        }

            //    case PresentStatusEnum.UpdateContent:
            //        {
            //            String[] dir = IconTextbox.Text.ToString().Split('\\');
            //            //MainTabControlViewModel.getInstance().updateContent(MainWindow.selected_tab, MainWindow.selected_content, dir[dir.Length - 1], TitleTextbox.Text.ToString(), ShellTextbox.Text.ToString());
            //            break;
            //        }
            //}
            //this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_onClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void IconSelectButton_onClick(object sender, RoutedEventArgs e)
        {
            ContentEditWindowViewModel vm = DataContext as ContentEditWindowViewModel;

            IconEditWindowViewModel.GetInstance((s) => {
                vm.IconPath = s;
                return 0;
            }).IconEditWindowVisibility = true;
        }

        private void ShellPathSelectButton_onClick(object sender, RoutedEventArgs e)
        {
            ContentEditWindowViewModel vm = DataContext as ContentEditWindowViewModel;
            OpenFileDialog dlgOpenFile = new OpenFileDialog();

            dlgOpenFile.Filter = "응용 프로그램 (*.exe) | *.exe;";

            if (dlgOpenFile.ShowDialog().ToString() == "OK")
            {
                vm.ShellPath = dlgOpenFile.FileName;
            }
        }

        #region VM Property

        #endregion
    }
}
