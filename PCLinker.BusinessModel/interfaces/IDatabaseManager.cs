﻿using ProgramCore.DAO;
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

        bool DeleteHeader(string title);
    }
}
