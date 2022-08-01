using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramCore.DAO
{
    public class HistoryDTO
    {
        public long Uid
        {
            get; set;
        }
        public long ContentUid
        {
            get; set;
        }
        public DateTime date
        {
            get; set;
        }
    }
}
