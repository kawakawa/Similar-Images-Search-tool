using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimilarImagesSearchToolTests.Util
{
    [TestClass]
    public class FolderTests
    {
        [TestMethod]
        public void フォルダ以外の場合Falseとなるか()
        {
            SimilarImagesSearchTool.Utli.Folder.IsFolder("./TestsFiles/sample1.zip").IsFalse();
        }

        [TestMethod]
        public void フォルダの場合Trueとなるか()
        {
            SimilarImagesSearchTool.Utli.Folder.IsFolder("./TestsFiles/").IsTrue();
        }
    }
}