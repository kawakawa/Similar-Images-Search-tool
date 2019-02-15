using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace SimilarImagesSearchTool.Model
{

    /// <summary>
    /// 物理フォルダ・ファイル全てを管理
    /// </summary>
    public class TargetFile
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _rootPath;

        private readonly FileInfo _fileInfo;


        /// <summary>
        /// 自身が持つ物理ファイル・フォルダ構造
        /// </summary>
        private List<TargetFile> _childrenFiles;

        /// <summary>
        /// 
        /// </summary>
        private List<VirtualTargetFile> _virtualTargetFiles;





        public static TargetFile Factory(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            if (Directory.Exists(path)==false)
                if (File.Exists(path)==false)
                    throw new ArgumentException("Target Path Not Exists");
            

            return new TargetFile(path);
        }



        private TargetFile(string rootPath)
        {
            _rootPath = rootPath;

            //当該ファイル・フォルダーのFileInfo取得
            _fileInfo = Utli.File.GetFileInfo(_rootPath);

            //物理フォルダ・ファイル構造解析
            Analyze();

            //当ファイルの仮想ファイル構造解析
            AnalyzeVirtual();
        }


        public IEnumerable<TargetFile> GetChildrenFiles()
        {
            return _childrenFiles;
        }

        public IEnumerable<VirtualTargetFile> GetChildrenVirtualFiles()
        {
            return _virtualTargetFiles;
        }


        /// <summary>
        /// RootPath配下のファイル一式を列挙します
        /// </summary>
        private void Analyze()
        {

            _childrenFiles=new List<TargetFile>();
            

            //解析対象がフォルダ以外の場合
            if (Utli.Folder.IsFolder(_rootPath)==false)
                return;

            var filesPath = Directory.EnumerateFileSystemEntries(_rootPath, "*", System.IO.SearchOption.TopDirectoryOnly);
            
            
            filesPath.ToList().ForEach(filePath =>
            {
                var targetFile =TargetFile.Factory(filePath);
                _childrenFiles.Add(targetFile);
            });

        }


        private void AnalyzeVirtual()
        {

            _virtualTargetFiles = new List<VirtualTargetFile>();


            //当ファイルがフォルダの場合
            if (Utli.Folder.IsFolder(_rootPath))
                return;



            //当ファイルがZIPファイルの場合
            if (Utli.File.IsZip(_fileInfo))
            {

                //ZIPに含まれているリソース一覧取得
                using (var archive = ZipFile.OpenRead(_fileInfo.FullName))
                {
                    foreach (var entry in archive.Entries)
                    {
                        //zipEntryのFullNameにはzipファイル名を含まれてしまうので、zipファイル名は除外する
                        var filename =
                            entry.FullName.Remove(0, Utli.File.GetFileNameWithoutExtension(_fileInfo).Length+1);

                        var virtualFile = VirtualTargetFile.Factory(_fileInfo, filename);
                        if (Utli.File.IsImage(entry.FullName))
                        {
                            var img = System.Drawing.Image.FromStream(entry.Open());
                            virtualFile.SetImageStream(img);
                        }

                        _virtualTargetFiles.Add(virtualFile);

                    }
                }
            }



            //zip以外
            var virtualTargetFile = VirtualTargetFile.Factory(_fileInfo, _fileInfo.Name);
            if (Utli.File.IsImage(_fileInfo.Name))
            {
                var img = System.Drawing.Image.FromFile(_fileInfo.FullName);
                virtualTargetFile.SetImageStream(img);
                _virtualTargetFiles.Add(virtualTargetFile);
            }


        }



    }
}
