using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimilarImagesSearchTool.Model
{

    /// <summary>
    /// 物理フォルダを管理
    /// </summary>
    public class TargetFiles
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _rootPath;


        private List<TargetFile> _files;






        public static TargetFiles Factory(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            if (Directory.Exists(path)==false)
                throw new ArgumentException("Target Path Not Exists");

            return new TargetFiles(path);
        }



        private TargetFiles(string rootPath)
        {
            _rootPath = rootPath;
        }

        /// <summary>
        /// RootPath配下のファイル一式を列挙します
        /// </summary>
        public void Analyze()
        {
            var di = new DirectoryInfo(_rootPath);
            var fileInfos = di.EnumerateFiles("*", SearchOption.AllDirectories)
                           .ToList();

            _files=new List<TargetFile>();

            fileInfos.ForEach(fileInfo =>
            {
                var targetFile =TargetFile.Factory(fileInfo);
                _files.Add(targetFile);
            });

        }

        public IEnumerable<TargetFile> GetFiles()
        {
            return _files;
        }



    }
}
