using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteComponent
{
    public class PCLinkerDB
    {
        private static PCLinkerDB instance;
        public static PCLinkerDB GetInstance()
        {
            if(instance == null)
            {
                instance = new PCLinkerDB();
            }
            return instance;
        }
        private ISQLite sql = new SQLite();

        public PCLinkerDB()
        {
            sql = new SQLite(Environment.CurrentDirectory, "default");
            while (!sql.OpenDataBase())
            {
                while (!sql.CreateDataBase()) ;
                if (sql.OpenDataBase())
                {
                    sql.ExecuteSQL("PRAGMA foreign_keys = 1;");

                    /****************************************************************************/
                    if (sql.ExecuteSQL("CREATE TABLE header (" +
                        "uid INTEGER PRIMARY KEY NOT NULL ," +
                        "title TEXT UNIQUE NULL DEFAULT NULL," +
                        "icon_path TEXT NULL DEFAULT NULL" +
                        ");" +
                        "" +
                        "CREATE TABLE content (" +
                        "uid INTERGER PRIMARY KEY NOT NULL ," +
                        "header_uid INTEGER NOT NULL," +
                        "title TEXT NULL DEFAULT NULL," +
                        "icon_path TEXT NULL DEFAULT NULL," +
                        "shell_path TEXT NULL DEFAULT NULL," +
                        "command TEXt NULL DEFAULT NULL," +
                        "CONSTRAINT header_uid_FK FOREIGN KEY(header_uid) REFERENCES header(uid) ON UPDATE CASCADE ON DELETE CASCADE" +
                        ");"))
                    {
                        sql.ExecuteSQL("INSERT INTO header(title, icon_path) VALUES (\"카테고리\", \"computer.ico\")");
                        Console.WriteLine("SQL Execute  Success");
                    }
                    else
                    {
                        Console.WriteLine("SQL Execute Failed");
                    }

                }
                else
                {
                    Console.WriteLine("SQL Open Failed");
                }
            }
        }


        public void AddHeader(string title, string icon_path)
        {
            sql.ExecuteSQL("INSERT INTO header(title, icon_path) VALUES (\"" + title + "\", \"" + icon_path + "\")");
        }

        public void DeleteHeader(long uid)
        {
            sql.ExecuteSQL("SELECT count(*) FROM header");
            var data = sql.GetData();
            int header_cnt = int.Parse(data[0]["count(*)"].ToString());
            if (header_cnt > 1)
                sql.ExecuteSQL("DELETE FROM header WHERE uid = " + uid);
            else
                throw new Exception("삭제할 수 없습니다.");
        }


    }
}
