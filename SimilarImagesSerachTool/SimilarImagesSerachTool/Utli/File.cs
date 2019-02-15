using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarImagesSearchTool.Utli
{
    public class File
    {
        public static FileInfo GetFileInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));


            return  new System.IO.FileInfo(path);

        }
    }
}
