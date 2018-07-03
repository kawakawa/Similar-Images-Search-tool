using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimilarImagesSerachTool.View;

namespace SimilarImagesSerachTool.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {
        private readonly View.MainWindow _mainWindow;


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



            
        }
    }
}
