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

namespace PCLinkerProject.Controls
{
    /// <summary>
    /// HeaderEditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HeaderEditWindow : UserControl
    {
        public HeaderEditWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_onClick(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_onClick(object sender, RoutedEventArgs e)
        {

        }

        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
