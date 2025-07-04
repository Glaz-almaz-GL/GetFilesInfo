using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFilesInfo
{
    public class MyFileInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int? PageCount { get; set; }
        public string FileCRC { get; set; }
    }

    public class MyFolderInfo
    {
        public int FolderId { get; set; }
        public string FolderPath { get; set; }
        public List<MyFileInfo> FolderFiles { get; set; }
    }
}
