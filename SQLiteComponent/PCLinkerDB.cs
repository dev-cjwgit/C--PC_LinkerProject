using ProgramCore.DAO;
using SQLiteComponent.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteComponent
{
    public class PCLinkerDB : IPCLinkerDB
    {

        private ISQLite sql;

        public PCLinkerDB()
        {
            sql = new SQLite();
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
                        "uid INTEGER PRIMARY KEY NOT NULL," +
                        "title TEXT UNIQUE NOT NULL," +
                        "icon_path TEXT NOT NULL DEFAULT \"computer.ico\"" +
                        ");" +
                        "" +
                        "CREATE TABLE content (" +
                        "uid INTEGER PRIMARY KEY NOT NULL ," +
                        "header_uid INTEGER NOT NULL," +
                        "title TEXT NULL DEFAULT NULL," +
                        "icon_path TEXT NULL DEFAULT \"computer.ico\"," +
                        "shell_path TEXT NULL DEFAULT \"\"," +
                        "command TEXT NULL DEFAULT \"\"," +
                        "CONSTRAINT header_uid_FK FOREIGN KEY(header_uid) REFERENCES header(uid) ON UPDATE CASCADE ON DELETE CASCADE ," +
                        "UNIQUE(header_uid, title)" +
                        ");" +
                        "" +
                        "CREATE TABLE history(" +
                        "uid INTEGER PRIMARY KEY NOT NULL," +
                        "content_uid INTEGER NOT NULL," +
                        "`date` TIMESTAMP NOT NULL," +
                        "CONSTRAINT content_uid_FK FOREIGN KEY (content_uid) REFERENCES content(uid) ON UPDATE CASCADE ON DELETE CASCADE" +
                        ")"))
                    {
                        long header_uid = CreateHeader("카테고리1", "computer.ico");
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

        public List<HeaderDTO> GetHeaderList()
        {
            List<HeaderDTO> result = new List<HeaderDTO>();
            sql.ExecuteSQL("SELECT * FROM header;");
            var tempdata = sql.GetData();
            foreach (var item in tempdata)
            {
                result.Add(new HeaderDTO()
                {
                    Uid = long.Parse(item["uid"].ToString()),
                    IconPath = item["icon_path"].ToString(),
                    Title = item["title"].ToString()
                });
            }
            return result;
        }

        public long GetHeaderUidByTitle(string title)
        {
            sql.ExecuteSQL("SELECT uid FROM header WHERE title = \"" + title +"\"");
            return long.Parse(sql.GetData()[0]["uid"].ToString());
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
            return sql.ExecuteSQL("DELETE FROM content WHERE uid = " + uid);
        }

        public bool DeleteContent(long header_uid, string title)
        {
            return sql.ExecuteSQL("DELETE FROM content WHERE header_uid = " + header_uid + " AND title = \"" + title + "\"");
        }

        public List<ContentDTO> GetContentList(long header_uid)
        {
            List<ContentDTO> result = new List<ContentDTO>();
            sql.ExecuteSQL("SELECT * FROM content WHERE header_uid = " + header_uid + ";");
            var tempdata = sql.GetData();
            foreach (var item in tempdata)
            {
                result.Add(new ContentDTO()
                {
                    Uid = long.Parse(item["uid"].ToString()),
                    HeaderUid = long.Parse(item["header_uid"].ToString()),
                    Title = item["title"].ToString(),
                    IconPath = item["icon_path"].ToString(),
                    ShellPath = item["shell_path"].ToString(),
                    Command = item["command"].ToString()
                });
            }
            return result;
        }

        public long GetContentUidByInfo(long header_uid, string content_title)
        {
            sql.ExecuteSQL("SELECT uid FROM content WHERE title = \"" + content_title + "\" AND header_uid = " + header_uid);
            return long.Parse(sql.GetData()[0]["uid"].ToString());
        }

        public long CreateHistory(long content_uid)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sql.ExecuteSQL("INSERT INTO history(`content_uid`, `date`) VALUES (" + content_uid + ", \"" + date + "\")");

            sql.ExecuteSQL("SELECT uid FROM history WHERE `date` = \"" + date + "\" AND content_uid = " + content_uid);
            long uid = long.Parse(sql.GetData()[0]["uid"].ToString());

            return uid;

        }

        public List<HistoryDTO> GetHistoryList()
        {
            List<HistoryDTO> result = new List<HistoryDTO>();
            sql.ExecuteSQL("SELECT * FROM content;");
            var tempdata = sql.GetData();
            foreach (var item in tempdata)
            {
                result.Add(new HistoryDTO()
                {
                    Uid = long.Parse(item["uid"].ToString()),
                    ContentUid = long.Parse(item["content_uid"].ToString()),
                    date = DateTime.Parse(item["date"].ToString())
                });
            }
            return result;
        }


    }
}
