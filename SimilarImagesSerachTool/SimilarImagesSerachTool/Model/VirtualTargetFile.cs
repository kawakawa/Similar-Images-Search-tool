using System.Drawing;
using System.IO;

namespace SimilarImagesSearchTool.Model
{
    public class VirtualTargetFile
    {


        public static VirtualTargetFile Factory(FileInfo baseFileInfo,string filename)
        {
            var virtualTargetFile = new VirtualTargetFile(baseFileInfo);
            virtualTargetFile.SetFileName(filename);


            return virtualTargetFile;
        }



        private readonly FileInfo _baseFileInfo;
        private string _filename;
        private Image _image;

        
        private VirtualTargetFile(FileInfo baseFileInfo)
        {
            _baseFileInfo = baseFileInfo;
        }


        public FileInfo GetFileInfo()
        {
            return _baseFileInfo;
        }

        private void SetFileName(string name)
        {
            _filename = name;
        }

        public string GetFileName()
        {
            return _filename;
        }



        public void SetImageStream(Image img)
        {
            _image = img;
        }
    }
}
