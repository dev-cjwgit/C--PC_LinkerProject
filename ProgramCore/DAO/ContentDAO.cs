using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCore.DAO
{
    public class ContentDAO
    {
        public long Uid { get; set; }

        public string HeaderTitle { get; set; }

        public string Title { get; set; }

        public string IconPath { get; set; }

        public string ShellPath { get; set; }

        public string Command { get; set; }
    }
}
