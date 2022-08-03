using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteComponent.interfaces
{
    public interface ISQLite
    {
        bool CreateDataBase();

        bool OpenDataBase();

        bool CloseDataBase();

        bool ExecuteSQL(string sql);

        bool ExecuteSQL(string[] sql);

        List<Dictionary<string, object>> GetData();
    }
}
