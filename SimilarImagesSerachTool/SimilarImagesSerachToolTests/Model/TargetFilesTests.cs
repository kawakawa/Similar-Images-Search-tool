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
        public void 存在しないフォルダを指定した場合Eception発生するかテスト()
        {
            AssertEx.Throws<ArgumentException>(() => TargetFiles.Factory(@"c:\Dummy\"));
        }



        [TestMethod]
        public void 存在するフォルダを指定した場合Nullが返ってこないかテスト()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/");
            targetFiles.IsNotNull();
        }


        [TestMethod]
        public void 空の対象フォルダ解析後_対象ファイルがゼロであることを確認()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/kara/");
            targetFiles.Analyze();
            var files = targetFiles.GetFiles();
            files.Count().Is(0);
        }


        [Ignore]
        [TestMethod]
        public void AA()
        {
            var targetFiles = TargetFiles.Factory("./TestsFiles/");
            targetFiles.Analyze();
            var files = targetFiles.GetFiles();
            files.IsNotNull();
            files.Count().Is(6);
            var fi = files.First();
            var vfs = fi.GetVirtualTargetFiles();
            vfs.IsNotNull();
            foreach (var virtualTargetFile in vfs)
            {
                virtualTargetFile.GetFileName().Is("");
            }


        }



}
}
