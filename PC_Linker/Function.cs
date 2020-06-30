using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PC_Linker
{
    public class Function
    {
        static NotifyIcon ICO = new NotifyIcon();

        public void SetICO(NotifyIcon ICOs)
        {
            ICO = ICOs;
        }
        public bool StartProgram(string Direction, string Factor, bool Admin)
        {
            try
            {
                ProcessStartInfo ProcInfo = new ProcessStartInfo(Direction);
                ProcInfo.UseShellExecute = true;
                if (Admin == true)
                {
                    ICO.BalloonTipTitle = "PC Linker";
                    ICO.BalloonTipText = "[" + Direction + "]\n을(를) 관리자 권한으로 실행합니다.";
                    ICO.ShowBalloonTip(1);
                    ProcInfo.Verb = "runas";
                }
                if (Factor == null)
                {
                    
                    Process.Start(ProcInfo);
                    return true;
                }
                else
                {
                    if (Admin == true)
                    {
                        ICO.BalloonTipTitle = "PC Linker";
                        ICO.BalloonTipText = "[" + Direction + "]\n의 프로그램 실행이 오류가 발생하였습니다.\nEx : 관리자로 실행하였거나 등등..";
                        ICO.ShowBalloonTip(1);
                        return false;
                    }
                    else
                    {
                        Process.Start(Direction, Factor);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public int Ubound(string[] Body)
        {
            int Count = 0;
            try
            {
                for (Count = 0; ; Count++)
                {
                    Strings.InStr(Body[Count], "");
                }
            }
            catch (Exception)
            {
                return Count;
            }
        }

        public int InstrSeach(string Body, string Seach)
        {
            int Count = 0;
            int Postion = 0;
            if (Strings.InStr(Body, Seach) != 0)
            {
                Postion = Strings.InStr(Body, Seach);
                for (Count = 1; ; Count++)
                {
                    if (Strings.InStr(Strings.Mid(Body, Postion + 1), Seach) != 0)
                    {
                        Postion = Postion + Strings.InStr(Strings.Mid(Body, Postion + 1), Seach);
                    }
                    else
                        return Count;
                }
            }
            else
                return 0;
        }
    }
}
