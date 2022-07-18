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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCLinkerProject
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private int selected_index = -1; // selected tab idx
        private int selected_item_index = -1; // selected listbox idx
        private WindowState PrevWindowState = WindowState.Normal;

        public MainWindow()
        {
            InitializeComponent();
            TabControl1.DataContext = MainTabControlViewModel.getInstance();

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

        private void ListBox1_StartProgram(object sender, MouseButtonEventArgs e)
        {
            dynamic meta_data = sender as dynamic;
            var temp = MainTabControlViewModel.getInstance(selected_index);
            Console.WriteLine(" " + temp[meta_data.SelectedIndex].ContentText);
        }

        private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Console");
            selected_index = (sender as System.Windows.Controls.TabControl).SelectedIndex;
        }

        private void ListBox1_Selected(object sender, SelectionChangedEventArgs e)
        {
            dynamic meta_data = sender as dynamic;
            selected_item_index = meta_data.SelectedIndex;
        }

        private void ListBox1_Update(object sender, RoutedEventArgs e)
        {
            var temp = MainTabControlViewModel.getInstance(selected_index);
            Console.WriteLine("U : " + temp[selected_item_index].ContentText);
        }

        private void ListBox1_Delete(object sender, RoutedEventArgs e)
        {
            // MainTabControlViewModel.getInstance().addContent(selected_index, "PyCharm.ico", textbox1.Text.ToString());
            // MainTabControlViewModel.getInstance().addTab("chrome.ico", textbox1.Text.ToString());
            var temp = MainTabControlViewModel.getInstance(selected_index);
            Console.WriteLine("D : " + temp[selected_item_index].ContentText);

            MainTabControlViewModel.getInstance().deleteContent(selected_index, selected_item_index);

        }
        private void WindowsConfigButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Temp_onClick(object sender, MouseButtonEventArgs e)
        {
            MainTabControlViewModel.getInstance().addTab("computer.ico", "임시1");
        }

        private void ListBox1_Append(object sender, RoutedEventArgs e)
        {

        }

        private void Header_Append(object sender, RoutedEventArgs e)
        {

        }

        private void Header_Update(object sender, RoutedEventArgs e)
        {

        }

        private void Header_Delete(object sender, RoutedEventArgs e)
        {
            MainTabControlViewModel.getInstance().deleteTab(selected_index);
        }

    }
}