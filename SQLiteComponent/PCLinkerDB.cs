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

        public bool CreateHeader(string title, string icon_path)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHeader(long uid, string title, string icon_path)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHeader(long uid)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHeader(string title)
        {
            throw new NotImplementedException();
        }

        public List<HeaderDAO> GetHeaderList()
        {
            throw new NotImplementedException();
        }

        public bool CreateContent(long header_uid, string title, string icon_path, string shell_path, string command)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContent(long uid, long header_uid, string title, string icon_path, string shell_path, string command)
        {
            throw new NotImplementedException();
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

        private ISQLite sql = new SQLite();

        public PCLinkerDB()
        {
            
        }

    }
}
