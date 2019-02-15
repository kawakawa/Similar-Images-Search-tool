using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimilarImagesSearchTool.Model
{

    /// <summary>
    /// 物理フォルダ・ファイル全てを管理
    /// </summary>
    public class TargetFiles
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _rootPath;


        private List<TargetFiles> _childrenFiles;






        public static TargetFiles Factory(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            if (Directory.Exists(path)==false)
                if (File.Exists(path)==false)
                    throw new ArgumentException("Target Path Not Exists");
            

            return new TargetFiles(path);
        }



        private TargetFiles(string rootPath)
        {
            _rootPath = rootPath;

            Analyze();
        }

        /// <summary>
        /// RootPath配下のファイル一式を列挙します
        /// </summary>
        private void Analyze()
        {

            _childrenFiles=new List<TargetFiles>();
            

            //解析対象がフォルダ以外の場合
            if (Utli.Folder.IsFolder(_rootPath)==false)
                return;

            var filesPath = Directory.EnumerateFileSystemEntries(_rootPath, "*", System.IO.SearchOption.TopDirectoryOnly);
            
            
            filesPath.ToList().ForEach(filePath =>
            {
                var targetFile =TargetFiles.Factory(filePath);
                _childrenFiles.Add(targetFile);
            });

        }

        public IEnumerable<TargetFiles> GetChildrenFiles()
        {
            return _childrenFiles;
        }



    }
}
