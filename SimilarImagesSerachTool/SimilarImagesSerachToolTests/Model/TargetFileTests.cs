using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimilarImagesSearchTool.Model;

namespace SimilarImagesSearchToolTests.Model
{
    [TestClass]
    public class TargetFileTests
    {
        [TestMethod]
        public void Nullや空白を指定した場合Eception発生するかテスト()
        {
            AssertEx.Throws<ArgumentNullException>(() => TargetFile.Factory(null));
            AssertEx.Throws<ArgumentNullException>(() => TargetFile.Factory("  "));
        }

        [TestMethod]
        public void 存在しないフォルダを指定した場合Exception発生するかテスト()
        {
            AssertEx.Throws<ArgumentException>(() => TargetFile.Factory(@"c:\Dummy\"));
        }

        [TestMethod]
        public void 存在しないファイルを指定した場合Exception発生するかテスト()
        {
            AssertEx.Throws<ArgumentException>(() => TargetFile.Factory(@"c:\Dummy.txt"));
        }
        

        [TestMethod]
        public void 存在するフォルダを指定した場合Nullが返ってこないかテスト()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/");
            targetFiles.IsNotNull();
        }

        [TestMethod]
        public void 存在するファイルを指定した場合Nullが返ってこないかテスト()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/sample1.zip");
            targetFiles.IsNotNull();
        }



        [TestMethod]
        public void 空の対象フォルダ解析後_対象ファイルがゼロであることを確認()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/kara/");
            
            var files = targetFiles.GetChildrenFiles();
            files.Count().Is(0);
        }

        [TestMethod]
        public void 空の対象フォルダ解析後_対象仮想ファイルがゼロであることを確認()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/kara/");

            var files = targetFiles.GetChildrenVirtualFiles();
            files.Count().Is(0);
        }






        [TestMethod]
        public void 画像ファイルが3個存在するフォルダの解析()
        {
            var tagetFiles = TargetFile.Factory("./TestsFiles/sample4_6/");

            var files = tagetFiles.GetChildrenFiles();
            files.Count().Is(3);
        }


        [TestMethod]
        public void 画像ファイルが3個存在するフォルダの解析で仮想ファイルはゼロであることを確認()
        {
            var tagetFiles = TargetFile.Factory("./TestsFiles/sample4_6/");

            var files = tagetFiles.GetChildrenVirtualFiles();
            files.Count().Is(0);
        }



        [TestMethod]
        public void ファイル3個とフォルダ3個存在するフォルダ解析の場合()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/");

            var files = targetFiles.GetChildrenFiles();
            files.IsNotNull();
            files.Count().Is(6);
        }



        [TestMethod]
        public void 画像ファイル解析の場合仮想ファイルが存在するか確認()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/sample4_6/image_4.jpg");

            var files = targetFiles.GetChildrenVirtualFiles();
            files.IsNotNull();
            files.Count().Is(1);
            files.First().GetFileName().Is("image_4.jpg");
        }

        [TestMethod]
        public void Zipファイル解析の場合仮想ファイルが存在するか確認()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/sample1.zip");

            var files = targetFiles.GetChildrenVirtualFiles();
            files.IsNotNull();
            files.Count().Is(1);
            files.First().GetFileName().Is("image_1.jpg");
        }


        [TestMethod]
        public void Zipファイルに2つファイルが存在するか確認()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/sample1_2.zip");

            var files = targetFiles.GetChildrenVirtualFiles();
            files.IsNotNull();
            files.Count().Is(2);
            files.Any(n=>n.GetFileName()== "image_1.jpg").IsTrue();
            files.Any(n => n.GetFileName() == "image_2.jpg").IsTrue();
        }


        [TestMethod]
        public void Zipファイルにフォルダとファイルが存在するか確認()
        {
            var targetFiles = TargetFile.Factory("./TestsFiles/sample7.zip");

            var files = targetFiles.GetChildrenVirtualFiles();
            files.IsNotNull();
            files.Count().Is(3);
            files.Any(n => n.GetFileName() == "image7_1.png").IsTrue();
            files.Any(n => n.GetFileName() == "sample7_1/sample7_2.png").IsTrue();
            files.Any(n => n.GetFileName() == "sample7_1/sample7_2/sample7_3.png").IsTrue();
            

        }

    }
}
