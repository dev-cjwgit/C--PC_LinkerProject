
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
    /// IconEditWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class IconEditWindow : System.Windows.Controls.UserControl
    {
        public IconEditWindow()
        {
            InitializeComponent();
        }

        private void ProgressBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void IconEdit_Selected(object sender, SelectionChangedEventArgs e)
        {
            //dynamic meta_data = sender as dynamic;
            //selected_index = meta_data.SelectedIndex;
        }

        private void AddButton_onClick(object sender, RoutedEventArgs e)
        {
            //String[] dir = IconTextbox.Text.Split('\\');
            //string fileName = dir[dir.Length - 1];
            //File.Copy(IconTextbox.Text, Environment.CurrentDirectory + @"\ICO\" + fileName);

            //IconEditViewModel.GetInstance().Tabs.Add(new HeaderItem()
            //{
            //    HeaderIcon = Environment.CurrentDirectory + @"\ICO\" + fileName,
            //    HeaderText = fileName
            //});
        }

        private void DeleteButton_onClick(object sender, RoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show("아직 지원 안합니다.\n직접 폴더에가서 지우고 프로그램을 재실행해주세요.");

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
            //OpenFileDialog dlgOpenFile = new OpenFileDialog();
            //dlgOpenFile.Filter = "Icon File (*.ico) | *.ico;";

            //if (dlgOpenFile.ShowDialog().ToString() == "OK")
            //{
            //    IconTextbox.Text = dlgOpenFile.FileName;
            //}
        }


        private void DialogButton_onClick(object sender, RoutedEventArgs e)
        {
            IconEditWindowViewModel IconEditVM = DataContext as IconEditWindowViewModel;

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "Icon File (*.ico) | *.ico;";

            if (dlgOpenFile.ShowDialog().ToString() == "OK")
            {
                IconEditVM.IconPathText = dlgOpenFile.FileName;
            }
        }

        private void SelectButton_onClick(object sender, MouseButtonEventArgs e)
        {
            // TODO : callback을 어떻게 처리해야할지 모르겠음..
            IconEditWindowViewModel IconEditVM = DataContext as IconEditWindowViewModel;
            if (IconEditWindowViewModel.callback != null)
            {
                IconEditWindowViewModel.callback(IconEditVM.IconSelectedItem.IconPath);
                IconEditVM.IconEditWindowVisibility = false;
            }

        }
    }
}
