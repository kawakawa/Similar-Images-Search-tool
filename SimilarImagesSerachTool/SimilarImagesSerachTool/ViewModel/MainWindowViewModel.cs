using System;
using SimilarImagesSearchTool.Model;
using SimilarImagesSearchTool.View;

namespace SimilarImagesSearchTool.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {
        private readonly MainWindow _mainWindow;


        public MainWindowViewModel()
        {
            _mainWindow = new MainWindow(this);
        }

        public void Show()
        {
            _mainWindow?.Show();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedPath"></param>
        internal void SetRootPath(string selectedPath)
        {
            if(string.IsNullOrWhiteSpace(selectedPath))
                throw new ArgumentNullException(nameof(selectedPath));

            var targetFiles = TargetFiles.Factory(selectedPath);
            targetFiles.Analyze();




        }
    }
}
