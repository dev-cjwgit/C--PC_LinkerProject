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
    }
}
