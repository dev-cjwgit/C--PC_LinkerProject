using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PCLinker.BusinessModel
{
    public class IconEditManager
    {
        public bool CopyIcon(string iconPath)
        {
            if (iconPath != "")
            {
                String[] dir = iconPath.Split('\\');
                string fileName = dir[dir.Length - 1];
                try
                {
                    File.Copy(iconPath, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PCLinker\ICO\" + fileName);

                    return true;
                }
                catch (IOException ex)
                {
                    if (ex.Message.Contains("파일이 이미 있습니다"))
                        return false;

                    throw ex;
                }
            }
            return false;
        }

        public bool DeleteIcon(string iconPath)
        {
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //FileInfo f = new FileInfo(iconPath);
            //f.Delete();

            //return true;
            throw new NotImplementedException();
        }
    }
}
