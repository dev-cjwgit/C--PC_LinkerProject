using PCLinker.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PCLinkerProject
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public class DoubleToCurrencyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double d = (double)value;
            return d.ToString("F0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public partial class MainWindow : Window
    {
       

        // starting
        //public static PCLinkerDB db;
        private WindowState PrevWindowState = WindowState.Normal;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

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
                NotifyIcon ni = new NotifyIcon();
                ni.Icon = new System.Drawing.Icon("ICO\\" + "computer.ico");
                ni.Visible = true;
                ni.Text = "PC Linker";

                ni.DoubleClick += (send, events) =>
                {
                    bool presTopmost = Topmost;
                    Topmost = true;
                    WindowState = WindowState.Normal;
                    PrevWindowState = WindowState;
                    DoubleAnimation anim2 = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.33));
                    BeginAnimation(OpacityProperty, anim2);
                    Topmost = presTopmost;
                    ni.Dispose();
                };

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


        private void WindowsConfigButton_Click(object sender, RoutedEventArgs e)
        {
            IconEditWindow.Visibility = Visibility.Visible;
        }

        private void Temp_onClick(object sender, MouseButtonEventArgs e)
        {
            //MainTabControlViewModel.getInstance().addTab("back.jpg", "임시1");

            //EditWindow.Visibility = Visibility.Visible;
        }
    }
}