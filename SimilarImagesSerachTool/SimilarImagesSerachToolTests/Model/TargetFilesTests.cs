using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIST= SimilarImagesSerachTool;

namespace SimilarImagesSerachToolTests.Model
{
    [TestClass]
    public class TargetFilesTests
    {
        [TestMethod]
        public void Nullや空白を指定した場合Eception発生するかテスト()
        {
            AssertEx.Throws<ArgumentNullException>(() => SIST.Model.TargetFiles.TargetFilesFactory(null));
            AssertEx.Throws<ArgumentNullException>(() => SIST.Model.TargetFiles.TargetFilesFactory("  "));
        }

        [TestMethod]
        public void 存在しないフォルダを指定した場合Eception発生するかテスト()
        {
            AssertEx.Throws<ArgumentException>(() => SIST.Model.TargetFiles.TargetFilesFactory(@"c:\Dummy\"));
        }



        [TestMethod]
        public void 存在するフォルダを指定した場合Nullが返ってこないかテスト()
        {
            var targetFiles = SIST.Model.TargetFiles.TargetFilesFactory("./TestsFiles/");
            targetFiles.IsNotNull();
        }


        [TestMethod]
        public void 空の対象フォルダ解析後_対象ファイルがゼロであることを確認()
        {
            var targetFiles = SIST.Model.TargetFiles.TargetFilesFactory("./TestsFiles/kara/");
            targetFiles.Analyze();

        }



    }
}
