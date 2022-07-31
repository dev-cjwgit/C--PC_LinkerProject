using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteComponent
{
    public class PCLinkerDB : IPCLinkerDB
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
            InitDB();
        }
        public bool InitDB()
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
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("SQL Open Failed");
                    return false;
                }
            }

            return true;
        }

        public long CreateHeader(string title, string icon_path)
        {
            sql.ExecuteSQL("INSERT INTO header(title, icon_path) VALUES (\"" + title + "\", \"" + icon_path + "\")");
            sql.ExecuteSQL("SELECT uid FROM header WHERE title = \"" + title + "\"");
            long uid = long.Parse(sql.GetData()[0]["uid"].ToString());

            return uid;
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

        public bool DeleteHeader(string title)
        {
            sql.ExecuteSQL("SELECT count(*) FROM header");
            var data = sql.GetData();
            int header_cnt = int.Parse(data[0]["count(*)"].ToString());
            if (header_cnt > 1)
                return sql.ExecuteSQL("DELETE FROM header WHERE title = \"" + title + "\"");
            else
                throw new Exception("삭제할 수 없습니다.");
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
                    Uid = long.Parse(item["uid"].ToString()),
                    IconPath = item["icon_path"].ToString(),
                    Title = item["title"].ToString()
                });
            }
            return result;
        }

        public long CreateContent(long header_uid, string title, string icon_path, string shell_path, string command)
        {
            sql.ExecuteSQL("INSERT INTO content(header_uid, title, icon_path,  shell_path, command) VALUES (" + header_uid + ",\"" + title + "\",\"" + icon_path + "\", \"" + shell_path + "\", \"" + command + "\");");

            sql.ExecuteSQL("SELECT uid FROM content WHERE title = \"" + title + "\" AND header_uid = " + header_uid);
            long uid = long.Parse(sql.GetData()[0]["uid"].ToString());
            return uid;
        }

        public bool UpdateContent(long uid, long header_uid, string title, string icon_path, string shell_path, string command)
        {
            return sql.ExecuteSQL("UPDATE content SET header_uid = " + header_uid + ", " +
                "title = \"" + title + "\", " +
                "icon_path = \"" + icon_path + "\", " +
                "shell_path = \"" + shell_path + "\", " +
                "command = \"" + command + "\" " +
                "WHERE uid = " + uid);
        }

        public bool DeleteContent(long uid)
        {
            throw new NotImplementedException();
        }

        public bool DeleteContent(long header_uid, string title)
        {
            throw new NotImplementedException();
        }

        public List<ContentDAO> GetContentList(long header_uid)
        {
            throw new NotImplementedException();
        }

        public bool CreateHistory(long content_uid)
        {
            throw new NotImplementedException();
        }



    }
}
