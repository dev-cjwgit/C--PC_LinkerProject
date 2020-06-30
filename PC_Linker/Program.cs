using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PC_Linker
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string MtxName = "PC Linker";
            Boolean MtxSuccess;
            Mutex Mtx = new Mutex(true, MtxName, out MtxSuccess);
            if (!MtxSuccess) {
                MessageBox.Show("이미 실행중입니다!.");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFrm());
            }
        }
    }
}
