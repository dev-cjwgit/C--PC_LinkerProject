using PCLinker.BusinessModel.interfaces;
using ProgramCore.DAO;
using SQLiteComponent;
using SQLiteComponent.interfaces;
using System;
using System.Collections.Generic;

namespace PCLinker.BusinessModel
{
    public class DatabaseManager : IDatabaseManager
    {
        private IPCLinkerDB db;
        public DatabaseManager()
        {
            db = new PCLinkerDB();
        }

        public IEnumerable<ContentDTO> GetContentList(long uid)
        {
            return db.GetContentList(uid);
        }

        public IEnumerable<HeaderDTO> GetHeaderList()
        {
            return db.GetHeaderList();
        }

        public bool CreateHeader(string title, string icon_path)
        {
            return db.CreateHeader(title, icon_path) > 0;
        }

        public bool UpdateHeader(string originTitle,  string title, string icon_path)
        {
            long uid = db.GetHeaderUidByTitle(originTitle);
            return db.UpdateHeader(uid, title, icon_path);
        }

        public bool DeleteHeader(string title)
        {
            try
            {
                return db.DeleteHeader(title);
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool CreateContent(string header_title, string title, string icon_path, string shell_path, string command)
        {
            try
            {
                long header_uid = db.GetHeaderUidByTitle(header_title);
                return db.CreateContent(header_uid, title, icon_path, shell_path, command) > 0;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateContent(string header_title, string origin_title, string title, string icon_path, string shell_path, string command)
        {
            long header_uid = db.GetHeaderUidByTitle(header_title);
            long content_uid = db.GetContentUidByInfo(header_uid, origin_title);
            return db.UpdateContent(content_uid, header_uid, title, icon_path, shell_path, command);
        }

        public bool DeleteContent(string header_title, string content_title)
        {
            long header_uid = db.GetHeaderUidByTitle(header_title);
            long content_uid = db.GetContentUidByInfo(header_uid, content_title);
            return db.DeleteContent(content_uid);
        }

        public bool CreateHistory(string header_title, string content_title)
        {
            long header_uid = db.GetHeaderUidByTitle(header_title);
            long content_uid = db.GetContentUidByInfo(header_uid, content_title);
            
            return db.CreateHistory(content_uid) > 0;
        }

    }
}
