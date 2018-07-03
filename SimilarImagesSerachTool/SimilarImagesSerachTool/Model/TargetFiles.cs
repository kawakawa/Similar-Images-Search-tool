using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarImagesSerachTool.Model
{
    public class TargetFiles
    {

        public static TargetFiles TargetFilesFactory(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            if (Directory.Exists(path)==false)
                throw new ArgumentException("Target Path Not Exists");

            return new TargetFiles(path);
        }



        private TargetFiles(string rootPath)
        {

        }




    }
}
