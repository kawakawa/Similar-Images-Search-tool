using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarImagesSearchTool.Utli
{
    public static class Folder
    {
        public static bool IsFolder(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            return System.IO.File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        }
    }
}
