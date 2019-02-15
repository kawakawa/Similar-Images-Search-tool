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

        public static bool IsZip(FileInfo fileInfo)
        {
            //当ファイルがZIPファイルの場合
            if (fileInfo.Name.ToLower().EndsWith(".zip"))
                return true;

            return false;
        }


        public static bool IsImage(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return false;

            if (filename.ToLower().EndsWith(".jpg"))
                return true;
            if (filename.ToLower().EndsWith(".gif"))
                return true;
            if (filename.ToLower().EndsWith(".png"))
                return true;
            if (filename.ToLower().EndsWith(".bmp"))
                return true;



            return false;
        }

        public static string GetFileNameWithoutExtension(FileInfo fileInfo)
        {
            var fullPath = fileInfo.FullName;
            return Path.GetFileNameWithoutExtension(fullPath);
        }








    }
}
