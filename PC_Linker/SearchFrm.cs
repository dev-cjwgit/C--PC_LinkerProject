using System;
using MetroFramework.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;


namespace PC_Linker
{
    public partial class SearchFrm : MetroForm
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        public bool ClosingStatus=false;
        [DllImport("user32")]
        public static extern UInt16 GetAsyncKeyState(Int32 vKey);

        Function Fun = new Function();
        public bool GetClosing()
        { return this.ClosingStatus; }
        NotifyIcon ICO = new NotifyIcon();
        public int MonitorX;
        public void SetICO(NotifyIcon ICOs)
        {
            ICO = ICOs;
        }
        public void SetClosing(bool value)
        { this.ClosingStatus = value; }
        public static bool IsKeyPressed(Int32 KeyCode)
        {
            return (GetAsyncKeyState(KeyCode) != 0) ? true : false;
        }

        public SearchFrm()
        {
            InitializeComponent();
        }
        public string KortoEngReplace(string Text)
        {
            string[] Kor = new string[] {"ㅂ","ㅈ","ㄷ","ㄱ","ㅅ","ㅛ","ㅕ","ㅑ","ㅐ","ㅔ","ㅁ","ㄴ","ㅇ","ㄹ","ㅎ","ㅗ","ㅓ","ㅏ","ㅣ","ㅋ","ㅌ","ㅊ","ㅍ","ㅠ","ㅜ","ㅡ","ㅒ","ㅖ" };
            string[] Kors = new string[] { "ㅃ", "ㅉ", "ㄸ", "ㄲ", "ㅆ" };
            string[] Eng = new string[] { "q","w","e","r","t","y","u","i","o","p","a","s","d","f","g","h","j","k","l","z","x","c","v","b","n","m","o","p"};
            for(int i=0;i<5;i++)
                Text = Text.Replace(Kors[i], Eng[i]);

            for (int i = 0; i < 26; i++)
            {
                Text = Text.Replace(Kor[i], Eng[i]);
            }

            return Text.ToLower();
        }
        private void SearchFrm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Screen.PrimaryScreen.Bounds.Width / 2, (uint)Screen.PrimaryScreen.Bounds.Height, 0,0);
            metroTextBox1.Focus();
            MonitorX = Screen.PrimaryScreen.Bounds.Width;
        }

        

        public void StartCommand(string Operand,string Operation,bool Admin)
        {
            try
            {
                switch (Operation)
                {
                    //case "df":
                    //case "dnf":
                    //case "ejsvk":
                    //case "ev":
                    //    Fun.StartProgram("explorer.exe", "http://df.nexon.com/", Admin);
                    //    break;

                    case "fhf":
                    case "lol":
                    case "fldhfp":
                        Fun.StartProgram(@"C:\Riot Games\League of Legends\LeagueClient.exe", null, Admin);
                        break;

                    case "tmqo":
                    case "qorm":
                    case "tq":
                    case "qr":
                    case "tmxlaqorm":
                        Fun.StartProgram("explorer.exe", "steam://rungameid/578080", Admin);
                        break;

                    case "tmxla":
                    case "tx":
                    case "steam":
                        Fun.StartProgram(@"C:\Program Files (x86)\Steam\Steam.exe", null, Admin);
                        break;

                    case "dnjsrir":
                    case "xlaqbdj":
                    case "teamviewer":
                    case "dr":
                    case "xqd":
                    case "xq":
                        Fun.StartProgram(@"C:\Program Files (x86)\TeamViewer\TeamViewer.exe", null, Admin);
                        break;

                    case "apffhs":
                    case "af":
                    case "melon":
                        Fun.StartProgram(@"C:\Program Files (x86)\Melon Player4\melon.exe", null, Admin);
                        break;

                    case "zmfha":
                    case "rnrmfzmfha":
                    case "googlechorme":
                    case "chorme":
                        Fun.StartProgram(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", null, Admin);
                        break;

                    case "shrtm":
                    case "sr":
                    case "nox":
                        Fun.StartProgram(@"D:\Program Files\Nox\bin\Nox.exe", null, Admin);
                        break;

                    case "cpu":
                    case "tlvldb":
                    case "tvd":
                    case "tlvldbdkdlel":
                    case "tvdde":
                        Fun.StartProgram(@"C:\Program Files\CPUID\HWMonitor\HWMonitor.exe", null, Admin);
                        break;

                    case "zkxhr":
                    case "zkzkdhxhr":
                    case "zzdx":
                    case "zx":
                    case "kakaotalk":
                        Fun.StartProgram(@"C:\Program Files (x86)\Kakao\KakaoTalk\KakaoTalk.exe", null, Admin);
                        break;

                    case "eltmzhem":
                    case "elzh":
                    case "ez":
                    case "discord":
                        Fun.StartProgram(@"C:\Users\hyeon\AppData\Local\Discord\app-0.0.305\Discord.exe", null, Admin);
                        break;

                    case "vs":
                    case "qlwndjftmxbeldh":
                    case "vs2017":
                        Fun.StartProgram(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\IDE\devenv.exe", null, Admin);
                        break;

                    case "flthtmdpelxj":
                    case "flthtm":
                    case "dpelxj":
                    case "ftt":
                    case "fttdex":
                    case "resouce":
                    case "resouceeditor":
                        Fun.StartProgram(@"C:\Program Files (x86)\ResourceEditor.exe", null, Admin);
                        break;

                    case "dprtpf":
                    case "excel":
                    case "dt":
                        Fun.StartProgram(@"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE", null, Admin);
                        break;

                    case "ppt":
                    case "vkdnjvhdlsxm":
                    case "vkvh":
                    case "vlvlxl":
                        Fun.StartProgram(@"C:\Program Files\Microsoft Office\root\Office16\POWERPNT.EXE", null, Admin);
                        break;

                    case "gksrmf":
                    case "gr":
                    case "hangle":
                        Fun.StartProgram(@"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\Hwp.exe", null, Admin);
                        break;

                    case "gkstpf":
                    case "gt1":
                    case "hancell":
                        Fun.StartProgram(@"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\HCell.exe", null, Admin);
                        break;

                    case "gkspdf":
                    case "pdf":
                        Fun.StartProgram(@"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\Hpdf.exe", null, Admin);
                        break;

                    case "gksty":
                    case "gt2":
                    case "hanshow":
                    case "gksppt":
                    case "hanppt":
                    case "show":
                        Fun.StartProgram(@"C:\Program Files (x86)\Hnc\Office 2018\HOffice100\Bin\HShow.exe", null, Admin);
                        break;

                    case "icue":
                        Fun.StartProgram(@"C:\Program Files (x86)\Corsair\CORSAIR iCUE Software\iCUE.exe", null, Admin);
                        break;

                    case "dlzmfflqtm":
                    case "dzft":
                    case "eclipse":
                    case "dlzmf":
                    case "java":
                    case "wkqk":
                    case "wq":
                        Fun.StartProgram(@"C:\Users\hyeon\eclipse\java-2019-06\eclipse\eclipse.exe", null, Admin);
                        break;
                    case "pycharm":
                    case "python":
                    case "vkdltjs":
                    case "py":
                    case "vdt":
                    case "vdc":
                    case "vkdlcka":
                        Fun.StartProgram(@"C:\Program Files\JetBrains\PyCharm Community Edition 2019.2.3\bin\pycharm64.exe", null, Admin);
                        break;

                    case "arduino":
                    case "dkendlsh":
                    case "deds":
                        Fun.StartProgram(@"C:\Program Files (x86)\Arduino\arduino.exe", null, Admin);
                        break;

                    case "sql":
                    case "znjfl":
                    case "db":
                    case "elql":
                    case "epdxjqpdltm":
                        Fun.StartProgram(@"C:\Program Files\HeidiSQL\heidisql.exe", null, Admin);
                        break;
                    case "vkdlfwlffk":
                    case "ftp":
                    case "vdwf":
                    case "filezilala":
                    case "vkdlftjqj":
                    case "vdtq":
                        Fun.StartProgram(@"C:\Program Files (x86)\FileZilla FTP Client\filezilla.exe", null, Admin);
                        break;
                    case "vpn":
                        Fun.StartProgram(@"C:\Program Files\SoftEther VPN Client\vpncmgr_x64.exe", null, Admin);
                        break;
                    default:
                        ICO.BalloonTipTitle = "프로그램 없음";
                        ICO.BalloonTipText =  "[" + Operation + "]\n프로그램이 목록에 존재하지 않습니다.";
                        ICO.ShowBalloonTip(1);
                        break;
                }
                ClosingStatus = true;
                this.Close();
            }
            catch (Exception ex)
            {
                ICO.BalloonTipTitle = "예외";
                ICO.BalloonTipText = ex.Message.ToString();
                ICO.ShowBalloonTip(1);
            }
            /*
            
                case "":
                case "":
                case "":
                case "":
                case "":
                    Fun.StartProgram(@"", null, Admin);
                    break;
            */

        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                if (IsKeyPressed(13) == true)
                {
                    if (Strings.Left(metroLabel1.Text, 1) == "!") {
                        if (Strings.Mid(metroLabel1.Text, 2, 2) == "st")
                        {
                            if (Fun.InstrSeach(metroLabel1.Text, "admin") != 0)
                            {
                                StartCommand(Strings.Split(Strings.Split(metroLabel1.Text, "!")[1], " ")[0],
                                    Strings.Split(metroLabel1.Text, " ")[1], true);
                            }
                            else
                            {
                                StartCommand(Strings.Split(Strings.Split(metroLabel1.Text, "!")[1], " ")[0],
                                    Strings.Split(metroLabel1.Text, " ")[1], false);
                            }
                        }else if (Strings.Mid(metroLabel1.Text, 2, 3) == "end") {
                            if(Strings.Split(metroLabel1.Text," ")[1] == "this") {
                                Application.ExitThread();
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            ICO.BalloonTipTitle = "알림";
                            ICO.BalloonTipText = "존재하지 않는 명령어입니다.";
                            metroLabel1.Text = "";
                            ICO.ShowBalloonTip(1);
                        }
                    }
                    else
                    {
                        ICO.BalloonTipTitle = "알림";
                        ICO.BalloonTipText = "존재하지 않는 명령어입니다.";
                        metroLabel1.Text = "";
                        ICO.ShowBalloonTip(1);
                    }
                }
                
                if (IsKeyPressed(8) == true )
                {
                    int StrLen = metroLabel1.Text.Length;
                    if (StrLen > 0)
                    {
                        metroLabel1.Text = Strings.Mid(metroLabel1.Text, 1, StrLen - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                ICO.BalloonTipTitle = "예외";
                ICO.BalloonTipText = ex.Message.ToString();
                ICO.ShowBalloonTip(1);
                metroLabel1.Text = null;

            }
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
        
        public void SearchFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosingStatus = GetClosing();
            if (ClosingStatus == false)
            {
                e.Cancel = true;
                ICO.BalloonTipTitle = "알림";
                ICO.BalloonTipText = "Ctrl + X를 눌러서 종료해주십시오.";
                ICO.ShowBalloonTip(1);
            }
            else
            {
                timer1.Enabled = false;
                e.Cancel = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //int x = Cursor.Position.X;
            //int y = Cursor.Position.Y;
            //Cursor.Position = new Point(Convert.ToInt32(this.Location.X.ToString()) + this.Width / 2, Convert.ToInt32(this.Location.Y.ToString()) + this.Height / 2);
            //Console.WriteLine(Convert.ToInt32(this.Location.X.ToString()) + ", " + Convert.ToInt32(this.Location.Y.ToString()));
            //Console.WriteLine("save " + x + ", " + y);
            this.WindowState = FormWindowState.Normal;
            //mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //Cursor.Position = new Point(x, y);
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            metroTextBox1.Focus();
            metroLabel1.Text += KortoEngReplace(metroTextBox1.Text);
            metroTextBox1.Text = "";
            metroTextBox1.Focus();
        }

        private void SearchFrm_Activated(object sender, EventArgs e)
        {
            //int x = Cursor.Position.X;
            //int y = Cursor.Position.Y;
            //Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            //mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            //Cursor.Position = new Point(x, y);
            this.WindowState = FormWindowState.Normal;
        }
    }
}
