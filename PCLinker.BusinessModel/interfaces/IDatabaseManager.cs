using ProgramCore.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCLinker.BusinessModel.interfaces
{
    public interface IDatabaseManager
    {
        IEnumerable<HeaderDTO> GetHeaderList();

        IEnumerable<ContentDTO> GetContentList(long uid);

        bool CreateHeader(string title, string icon_path);
        bool UpdateHeader(string originTitle, string title, string icon_path);
        bool DeleteHeader(string title);

        bool CreateContent(string header_title, string title, string icon_path, string shell_path, string command);
        bool UpdateContent(string header_title, string origin_title, string title, string icon_path, string shell_path, string command);
        bool DeleteContent(string header_title, string content_title);

        bool CreateHistory(string header_title, string content_title);
    }
}
