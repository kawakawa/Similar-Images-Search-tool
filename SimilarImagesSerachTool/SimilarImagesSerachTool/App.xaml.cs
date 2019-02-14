using System.Windows;

namespace SimilarImagesSearchTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var vm = new SimilarImagesSearchTool.ViewModel.MainWindowViewModel();
            vm.Show();
        }
    }
}
