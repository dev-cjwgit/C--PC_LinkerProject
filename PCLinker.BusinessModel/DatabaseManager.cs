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

    }
}
