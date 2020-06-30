using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MetroFramework.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Management;
using OpenHardwareMonitor.Hardware;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace PC_Linker
{
    public partial class MainFrm : MetroForm
    {
        int thiswidth = 344;
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private const int WS_SHOWNORMAL = 1;
        [DllImport("user32")]
        public static extern UInt16 GetAsyncKeyState(Int32 vKey);
        static bool SearchStatus = true;
        static RegistryKey rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        static Function Fun = new Function();
        static public SearchFrm Frm = new SearchFrm();
        public int MonitorX, MonitorY;
        public static bool IsKeyPressed(Int32 KeyCode)
        {
            return (GetAsyncKeyState(KeyCode) != 0) ? true : false;
        }

        public MainFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\TeamViewer\TeamViewer.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.Width = 344;
            Fun.SetICO(notifyIcon1);
            notifyIcon1.Visible = true;this.Enabled = true;
            this.TopMost = true;
            MonitorX = Screen.PrimaryScreen.Bounds.Width;
            MonitorY = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point((int)(MonitorX / 1.25), (int)(MonitorY / 70));
            if (rkey.GetValue("PC_Linker") == null)
            {
                metroButton1.Text = "ADD Start Program";
            }
            else
            {
                metroButton1.Text = "DEL Start Program";
            }
            //this.Location = new Point(-375, 10);
        }

        private void pictureBox100_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Riot Games\League of Legends\LeagueClient.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label100_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Riot Games\League of Legends\LeagueClient.exe";
            if (IsKeyPressed(17) == true)
            {
                if (Fun.StartProgram(Url, null, true) == false)
                {
                    MessageBox.Show("실행에 실패하였습니다.");
                }
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox200_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Steam\Steam.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label200_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Steam\Steam.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox201_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\TeamViewer\TeamViewer.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox300_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Kakao\KakaoTalk\KakaoTalk.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label300_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Kakao\KakaoTalk\KakaoTalk.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox301_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Users\hyeon\AppData\Local\Discord\app-0.0.305\Discord.exe";
            if (IsKeyPressed(17) == true)
            {
                if (IsKeyPressed(17) == true)
                {
                    Fun.StartProgram(Url, null, true);
                }
                else
                {
                    Fun.StartProgram(Url, null, false);
                }
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label301_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Users\hyeon\AppData\Local\Discord\app-0.0.305\Discord.exe";
            if (IsKeyPressed(17) == true)
            {
                if (IsKeyPressed(17) == true)
                {
                    Fun.StartProgram(Url, null, true);
                }
                else
                {
                    Fun.StartProgram(Url, null, false);
                }
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox400_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\devenv.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label400_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\devenv.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox500_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label500_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox501_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files\Microsoft Office\root\Office16\POWERPNT.EXE";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label501_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files\Microsoft Office\root\Office16\POWERPNT.EXE";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox510_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\Hwp.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label510_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\Hwp.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox511_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\Hpdf.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label511_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\Hpdf.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroButton1.Text == "ADD Start Program")
            {
                try
                {
                    rkey.Close();
                    rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    rkey.SetValue("PC_Linker", @"C:\PC_Linker.exe");
                    MessageBox.Show("시작프로그램 등록이 완료 되었습니다.");
                    metroButton1.Text = "DEL Start Program";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (metroButton1.Text == "DEL Start Program")
            {
                try
                {
                    rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    rkey.DeleteValue("PC_Linker");
                    metroButton1.Text = "ADD Start Program";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


        }

        public void MainFrm_Move(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.Location.X.ToString()) < 10)
            {
                this.Location = new Point(10, this.Location.Y);
            }
            if (Convert.ToInt32(this.Location.X.ToString()) > MonitorX * 2 - this.Width - 10)
            {
                this.Location = new Point(MonitorX * 2 - (this.Width + 10), this.Location.Y);
            }

            if (Convert.ToInt32(this.Location.Y.ToString()) < 10)
            {
                this.Location = new Point(this.Location.X, 10);
            }

            if (Convert.ToInt32(this.Location.Y.ToString()) > MonitorY - this.Height - 10)
            {
                this.Location = new Point(this.Location.X, MonitorY - (this.Height + 10));
            }
            Console.WriteLine(this.Location.X + " " + this.Location.Y);
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (IsKeyPressed(17) & IsKeyPressed(18) & IsKeyPressed(83) & SearchStatus == true)
            {
                SetForegroundWindow(this.Handle);
                SystemParametersInfo((uint)0x2001, 0, 0, 0x0002 | 0x0001);
                ShowWindowAsync(Frm.Handle, WS_SHOWNORMAL);
                SetForegroundWindow(Frm.Handle);
                SystemParametersInfo((uint)0x2001, 200000, 200000, 0x0002 | 0x0001);
                SearchStatus = false;
                Frm.BringToFront();
                Frm.SetICO(notifyIcon1);
                Frm.TopMost = true;
                Frm.Activate();
                Frm.ShowDialog();
                SearchStatus = true;
                Frm = new SearchFrm();
            }
            if (IsKeyPressed(17) & IsKeyPressed(18) & IsKeyPressed(88) & SearchStatus == false)
            {
                SearchStatus = true;
                Frm.ClosingStatus = true;
                Frm.Close();
                Frm = new SearchFrm();
            }
            if (IsKeyPressed(18) & IsKeyPressed(187) == true)
            {
                this.Width = thiswidth;
                this.Height = 297;
                this.Show();
                this.Enabled = true;
                this.Visible = true;
            }
            if (IsKeyPressed(18) & IsKeyPressed(189) & IsKeyPressed(16) == true)
            {
                if(this.Width > 100)
                    thiswidth = this.Width;
                this.Visible = false;
                this.Enabled = false;
                this.Width = 0;
                this.Height = 0;
                notifyIcon1.BalloonTipTitle = "트레이모드";
                notifyIcon1.BalloonTipText = "트레이모드 입니다.\nCtrl와Shift = 를 함께 누르시면 트레이모드가 취소됩니다.";
                notifyIcon1.ShowBalloonTip(1);
                //notifyIcon1.ShowBalloonTip(5);
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thiswidth = this.Width;
            e.Cancel = true;
            this.Visible = true;
            this.ShowIcon = true;
            this.Visible=false;
            this.Width = 0;
            this.Height = 0;
            notifyIcon1.BalloonTipTitle = "트레이모드";
            notifyIcon1.BalloonTipText = "트레이모드 입니다.\nCtrl와Shift = 를 함께 누르시면 트레이모드가 취소됩니다.";
            notifyIcon1.ShowBalloonTip(1);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Width = 344;
            this.Height = 297;
       
            this.Enabled = true;
            this.Visible = true;
        }

        private void pictureBox206_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Corsair\CORSAIR iCUE Software\iCUE.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label206_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Corsair\CORSAIR iCUE Software\iCUE.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (metroButton2.Text == ">")
            {
                if (this.Width >= 712)
                {

                    metroButton2.Text = "<";
                    this.Width = 712;
                    MainFrm_Move(null, e);
                    timer2.Enabled = false;
                }
                else
                {
                    this.Width += 10;
                    MainFrm_Move(null, e);
                }
            }
            else if (metroButton2.Text == "<")
            {
                if (this.Width <= 344)
                {
                    metroButton2.Text = ">";
                    this.Width = 344;
                    MainFrm_Move(null, e);
                    timer2.Enabled = false;
                }
                else
                {
                    this.Width -= 10;
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        
        private void metroCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private static void AddCpuInfo(StringBuilder sb,  IHardware hardwareItem)
        {
            hardwareItem.Update();
            foreach (IHardware subHardware in hardwareItem.SubHardware)
                subHardware.Update();

            string text;

            foreach (var sensor in hardwareItem.Sensors)
            {
                string name = sensor.Name;
                string value = sensor.Value.HasValue ? sensor.Value.Value.ToString() : "-1";

                switch (sensor.SensorType)
                {
                    case SensorType.Temperature:
                        text = $"1{name} Temperature = {value}";
                        sb.AppendLine(text);
                        break;
                    //case SensorType.Voltage:
                    //    text = $"2{name} Voltage = {value}";
                    //    sb.AppendLine(text);
                    //    break;

                    //case SensorType.Fan:
                    //    text = $"3{name} RPM = {value}";
                    //    sb.AppendLine(text);
                    //    break;
                    case SensorType.Load:
                        text = $"2{name} % = {value}";
                        sb.AppendLine(text);
                        break;
                }
            }
        }


        private void pictureBox401_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files\JetBrains\PyCharm Community Edition 2020.1.1\bin\pycharm64.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }



        private void pictureBox101_Click(object sender, EventArgs e)
        {
            string Url = @"explorer.exe";
            if (Fun.StartProgram(Url, "steam://rungameid/578080", false) == false)
            {
                MessageBox.Show("실행에 실패하였습니다.");
            }
        }

        private void label101_Click(object sender, EventArgs e)
        {
            string Url = @"explorer.exe";
            if (Fun.StartProgram(Url, "steam://rungameid/578080", false) == false)
            {
                MessageBox.Show("실행에 실패하였습니다.");
            }
        }

        private void pictureBox202_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void label202_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }

        private void pictureBox102_Click(object sender, EventArgs e)
        {
            string Url = @"explorer.exe";
            if (Fun.StartProgram(Url, "com.epicgames.launcher://apps/9d2d0eb64d5c44529cece33fe2a46482?action=launch", false) == false)
            {
                MessageBox.Show("실행에 실패하였습니다.");
            }
        }

        private void label102_Click(object sender, EventArgs e)
        {
            string Url = @"explorer.exe";
            if (Fun.StartProgram(Url, "com.epicgames.launcher://apps/9d2d0eb64d5c44529cece33fe2a46482?action=launch", false) == false)
            {
                MessageBox.Show("실행에 실패하였습니다.");
            }
        }

        private void label401_Click(object sender, EventArgs e)
        {
            string Url = @"C:\Program Files\JetBrains\PyCharm Community Edition 2020.1.1\bin\pycharm64.exe";
            if (IsKeyPressed(17) == true)
            {
                Fun.StartProgram(Url, null, true);
            }
            else
            {
                Fun.StartProgram(Url, null, false);
            }
        }
    }
}