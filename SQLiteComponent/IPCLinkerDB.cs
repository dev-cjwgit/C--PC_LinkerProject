using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteComponent
{
    public interface IPCLinkerDB
    {
        bool InitDB();
        // CRUD
        bool CreateHeader(string title, string icon_path);
        bool UpdateHeader(long uid, string title, string icon_path);
        bool DeleteHeader(long uid);
        bool DeleteHeader(string title);
        List<HeaderDAO> GetHeaderList();

        bool CreateContent(long header_uid, string title, string icon_path, string shell_path, string command);
        bool UpdateContent(long uid, long header_uid, string title, string icon_path, string shell_path, string command);
        bool DeleteContent(long uid);
        bool DeleteContent(long header_uid, string title);
        List<ContentDAO> GetContentList(long header_uid);

    }
}
