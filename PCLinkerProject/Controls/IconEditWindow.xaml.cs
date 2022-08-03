
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
    /// IconEditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public delegate void Selection(string data);

    public partial class IconEditWindow : System.Windows.Controls.UserControl
    {
        public static Selection send1;
        public static Selection send2;
        private int selected_index;
        public IconEditWindow()
        {
            InitializeComponent();
            //IconEditListbox.ItemsSource = IconEditViewModel.GetInstance().Tabs;

            //IconEditViewModel.GetInstance().Tabs.Clear();
            //// TODO: 2번 호출되는 이유 찾고 오류 고쳐야함
            //string[] files = Directory.GetFiles(Environment.CurrentDirectory + @"\ICO\", "*.ico");
            //foreach (var file in files)
            //{
            //    String[] split = file.Split('\\');
            //    IconEditViewModel.GetInstance().Tabs.Add(new HeaderItem()
            //    {
            //        HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + split[split.Length - 1],
            //        HeaderText = split[split.Length - 1]
            //    });
            //}

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

        private void IconEdit_Selected(object sender, SelectionChangedEventArgs e)
        {
            dynamic meta_data = sender as dynamic;
            selected_index = meta_data.SelectedIndex;
        }

        private void AddButton_onClick(object sender, RoutedEventArgs e)
        {
            String[] dir = IconTextbox.Text.Split('\\');
            string fileName = dir[dir.Length - 1];
            File.Copy(IconTextbox.Text, Environment.CurrentDirectory + @"\ICO\" + fileName);

            //IconEditViewModel.GetInstance().Tabs.Add(new HeaderItem()
            //{
            //    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + fileName,
            //    HeaderText = fileName
            //});
        }

        private void DeleteButton_onClick(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("아직 지원 안합니다.\n직접 폴더에가서 지우고 프로그램을 재실행해주세요.");

            //File.Delete(IconEditViewModel.GetInstance().Tabs[selected_index].HeaderIcon.ToString());
            //IconEditViewModel.GetInstance().Tabs.RemoveAt(selected_index);

            //selected_index = -1;
        }

        private void CancelButton_onClick(object sender, RoutedEventArgs e)
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

        private void CheckDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //dynamic meta_data = sender as dynamic;
            //var temp = IconEditViewModel.GetInstance().Tabs[selected_index];
            //String[] dir = temp.HeaderIcon.ToString().Split('\\');
            //send1(dir[dir.Length - 1]);
            //send2(dir[dir.Length - 1]);
            //this.Visibility = Visibility.Collapsed;
        }
    }
}
