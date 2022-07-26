using PCLinkerProject.VMs;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCLinkerProject.Controls
{
    /// <summary>
    /// IconEditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class IconEditWindow : UserControl
    {
        public IconEditWindow()
        {
            InitializeComponent();
            IconEditListbox.ItemsSource = IconEditViewModel.GetInstance().Tabs;


            string[] files = Directory.GetFiles(@"C:\File", "*.txt");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            //IconEditViewModel.GetInstance().Tabs.Add(new HeaderItem()
            //{
            //    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + "computer.ico",
            //    HeaderText = "컴퓨터"
            //});
        }

        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
