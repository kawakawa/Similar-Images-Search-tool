using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace SimilarImagesSearchTool.Model
{
    public class TargetFile
    {

        private readonly FileInfo _fileInfo;
        private List<VirtualTargetFile> _virtualTargetFiles;

        public static TargetFile Factory(FileInfo fileInfo)
        {
            var targetfile = new TargetFile(fileInfo);
            var virtualfiles = targetfile.AnalyzeVirtualTargetFiles();
            targetfile.SetVirtualTargetFiles(virtualfiles);
            return targetfile;
        }


        private TargetFile(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public FileInfo GetFileInfo()
        {
            return _fileInfo;
        }


        public void SetVirtualTargetFiles(IEnumerable<VirtualTargetFile> virtualTargetFiles)
        {
            _virtualTargetFiles = virtualTargetFiles.ToList();
        }

        public IEnumerable<VirtualTargetFile> GetVirtualTargetFiles()
        {
            return _virtualTargetFiles;
        }




        public IEnumerable<VirtualTargetFile> AnalyzeVirtualTargetFiles()
        {
            //当ファイルがZIPファイルの場合
            if (IsZip(_fileInfo))
            {
                var vfiles = new List<VirtualTargetFile>();

                //ZIPに含まれているリソース一覧取得
                using (var archive = ZipFile.OpenRead(_fileInfo.FullName))
                {

                    
                    foreach (var entry in archive.Entries)
                    {
                        var vfile = VirtualTargetFile.Factory(_fileInfo, entry.FullName);
                        if (IzImange(entry.FullName))
                        {
                            var img = System.Drawing.Image.FromStream(entry.Open());
                            vfile.SetImageStream(img);
                        }

                        vfiles.Add(vfile);

                    }
                }

                return vfiles;

            }

            //zip以外
            var virtualTargetFile = VirtualTargetFile.Factory(_fileInfo, _fileInfo.Name);
            if (IzImange(_fileInfo.Name))
            {
                var img = System.Drawing.Image.FromFile(_fileInfo.FullName);
                virtualTargetFile.SetImageStream(img);
            }


            return new List<VirtualTargetFile>()
            {
                virtualTargetFile,
            };

        }








        public static bool IsZip(FileInfo fileInfo)
        {
            //当ファイルがZIPファイルの場合
            if (fileInfo.Name.ToLower().EndsWith(".zip"))
                return true;

            return false;
        }


        public static bool IzImange(string filename)
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


    }
}
