using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimilarImagesSearchTool.Model;

namespace SimilarImagesSearchToolTests.Model
{
    [TestClass]
    public class TargetFilesTests
    {
        [TestMethod]
        public void Nullや空白を指定した場合Eception発生するかテスト()
        {
            AssertEx.Throws<ArgumentNullException>(() => TargetFiles.Factory(null));
            AssertEx.Throws<ArgumentNullException>(() => TargetFiles.Factory("  "));
        }

        [TestMethod]
        public void 存在しないフォルダを指定した場合Exception発生するかテスト()
        {
            AssertEx.Throws<ArgumentException>(() => TargetFiles.Factory(@"c:\Dummy\"));
        }

        [TestMethod]
        public void 存在しないファイルを指定した場合Exception発生するかテスト()
        {
            AssertEx.Throws<ArgumentException>(() => TargetFiles.Factory(@"c:\Dummy.txt"));
        }
        

        [TestMethod]
        public void 存在するフォルダを指定した場合Nullが返ってこないかテスト()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/");
            targetFiles.IsNotNull();
        }

        [TestMethod]
        public void 存在するファイルを指定した場合Nullが返ってこないかテスト()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/sample1.zip");
            targetFiles.IsNotNull();
        }



        [TestMethod]
        public void 空の対象フォルダ解析後_対象ファイルがゼロであることを確認()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/kara/");
            
            var files = targetFiles.GetChildrenFiles();
            files.Count().Is(0);
        }


        [TestMethod]
        public void 画像ファイルが3個存在するフォルダの解析()
        {
            var tagetFiles = TargetFiles.Factory("./TestsFiles/sample4_6/");

            var files = tagetFiles.GetChildrenFiles();
            files.Count().Is(3);

        }
        
        [TestMethod]
        public void ファイル2個とフォルダ3個存在するフォルダ解析の場合()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/");

            var files = targetFiles.GetChildrenFiles();
            files.IsNotNull();
            files.Count().Is(5);


        }



}
}
