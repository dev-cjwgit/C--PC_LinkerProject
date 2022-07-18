﻿using PCLinkerProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCLinkerProject.controls
{
    /// <summary>
    /// EditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditWindow : UserControl
    {

        public EditWindow()
        {
            InitializeComponent();
        }

        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            
        }

        private void AcceptButton_onClick(object sender, RoutedEventArgs e)
        {

            switch (MainWindow.presentStatus)
            {
                case PresentStatusEnum.None:
                    {
                        break;
                    }

                case PresentStatusEnum.AddTab:
                    {
                        MainTabControlViewModel.getInstance().addTab(IconTextbox.Text.ToString(), TitleTextbox.Text.ToString());
                        break;
                    }
                case PresentStatusEnum.UpdateTab:
                    {
                        
                        break;
                    }

                case PresentStatusEnum.AddContent:
                    {
                        MainTabControlViewModel.getInstance().addContent(MainWindow.selected_tab, IconTextbox.Text.ToString(), TitleTextbox.Text.ToString(), ShellTextbox.Text.ToString());
                        break;
                    }

                case PresentStatusEnum.UpdateContent:
                    {
                        break;
                    }
            }
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_onClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
