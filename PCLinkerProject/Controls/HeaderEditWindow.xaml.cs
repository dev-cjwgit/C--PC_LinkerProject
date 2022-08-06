
using PCLinker.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
            DataContext = new HeaderEditWindowViewModel();
            //IconEditWindow.send1 = recv;
        }

        private void AcceptButton_onClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_onClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void IconSelectButton_onClick(object sender, RoutedEventArgs e)
        {
            HeaderEditWindowViewModel vm = DataContext as HeaderEditWindowViewModel;
            System.Windows.Controls.ListBox list = new System.Windows.Controls.ListBox();

            IconEditWindowViewModel.GetInstance((s) => {
                vm.IconPath = s;
                return 0;
            }).IconEditWindowVisibility = true;
            //IconEditWindow.Visibility = Visibility.Visible;
            //OpenFileDialog dlgOpenFile = new OpenFileDialog();

            //dlgOpenFile.Filter = "Icon File (*.ico) | *.ico;";



            //if (dlgOpenFile.ShowDialog().ToString() == "OK")
            //{
            //    IconTextbox.Text = dlgOpenFile.FileName;
            //}
        }
    }
}
