using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Text;
//
namespace SQLiteComponent
{
    public class PCLinkerDB
    {
        private static PCLinkerDB instance;
        public static PCLinkerDB GetInstance()
        {
            if (instance == null)
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
                        "title TEXT PRIMARY KEY NOT NULL," +
                        "icon_path TEXT NULL DEFAULT NULL" +
                        ");" +
                        "" +
                        "CREATE TABLE content (" +
                        "uid INTEGER PRIMARY KEY NOT NULL ," +
                        "header_title TEXT NOT NULL," +
                        "title TEXT NULL DEFAULT NULL," +
                        "icon_path TEXT NULL DEFAULT NULL," +
                        "shell_path TEXT NULL DEFAULT \"\"," +
                        "command TEXT NULL DEFAULT \"\"," +
                        "CONSTRAINT header_title_FK FOREIGN KEY(header_title) REFERENCES header(title) ON UPDATE CASCADE ON DELETE CASCADE" +
                        ");"))
                    {
                        sql.ExecuteSQL("INSERT INTO header(title, icon_path) VALUES (\"카테고리\", \"computer.ico\")");
                        sql.ExecuteSQL("INSERT INTO content(header_title, title, icon_path,  shell_path, command) VALUES (\"카테고리\",\"김치찌개\",\"computer.ico\", \"\", \"\");");
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

        public List<HeaderDAO> GetHeaderList()
        {
            List<HeaderDAO> result = new List<HeaderDAO>();
            sql.ExecuteSQL("SELECT * FROM header;");
            var tempdata = sql.GetData();
            foreach (var item in tempdata)
            {
                result.Add(new HeaderDAO()
                {
                    IconPath = item["icon_path"].ToString(),
                    Title = item["title"].ToString()
                });
            }
            return result;
        }

        public int getHeaderUidByTitle(string title)
        {
            sql.ExecuteSQL("SELECT uid FROM header WHERE title = \"" + title + "\"");
            var data = sql.GetData();
            return int.Parse(data[0]["uid"].ToString());
        }

        public bool AddHeader(string title, string icon_path)
        {
            return sql.ExecuteSQL("INSERT INTO header(title, icon_path) VALUES (\"" + title + "\", \"" + icon_path + "\")");
        }

        public bool UpdateHeader(long uid, string title, string icon_path)
        {
            return sql.ExecuteSQL("UPDATE header SET title = \"" + title + "\", icon_path = \"" + icon_path + "\" WHERE uid = " + uid);
        }

        public bool DeleteHeader(long uid)
        {
            sql.ExecuteSQL("SELECT count(*) FROM header");
            var data = sql.GetData();
            int header_cnt = int.Parse(data[0]["count(*)"].ToString());
            if (header_cnt > 1)
                return sql.ExecuteSQL("DELETE FROM header WHERE uid = " + uid);
            else
                throw new Exception("삭제할 수 없습니다.");
        }


        public bool addContent(string header_title, string icon_path, string title, string shell_path, string command)
        {
            return sql.ExecuteSQL("INSERT INTO content(header_title, title, icon_path,  shell_path, command) VALUES (\"" + header_title + "\",\"" + title + "\",\"" + icon_path + "\", \"" + shell_path + "\", \"" + command + "\");");
        }
    }
}
