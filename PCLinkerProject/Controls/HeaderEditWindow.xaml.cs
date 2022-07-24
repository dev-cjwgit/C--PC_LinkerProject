using PCLinkerProject.ViewModel;
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
    /// HeaderEditWindow.xaml에 대한 상호 작용 논리
    /// </summary> test
    public partial class HeaderEditWindow : System.Windows.Controls.UserControl
    {
        public HeaderEditWindow()
        {
            InitializeComponent();
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
                        String[] path = IconTextbox.Text.ToString().Split('\\');

                        MainTabControlViewModel.getInstance().addTab(IconTextbox.Text.ToString(), TitleTextbox.Text.ToString());
                        break;
                    }
                case PresentStatusEnum.UpdateTab:
                    {
                        MainTabControlViewModel.getInstance().updateTab(MainWindow.selected_tab, IconTextbox.Text.ToString(), TitleTextbox.Text.ToString());
                        break;
                    }
            }
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_onClick(object sender, RoutedEventArgs e)
        {

        }

        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void IconSelectButton_onClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();

            dlgOpenFile.Filter = "Icon File (*.ico) | *.ico;";



            if (dlgOpenFile.ShowDialog().ToString() == "OK")
            {
                IconTextbox.Text = dlgOpenFile.FileName;

            }
        }
    }
}
