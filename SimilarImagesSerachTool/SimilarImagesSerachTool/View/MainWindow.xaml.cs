using System.Windows;
using System.Windows.Forms;

namespace SimilarImagesSearchTool.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SimilarImagesSearchTool.ViewModel.MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(SimilarImagesSearchTool.ViewModel.MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            _vm = vm;
        }

        private void RootFolderSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog {Description = @"類似画材検索する対象フォルダROOTを選択して下さい"};
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _vm.SetRootPath(dialog.SelectedPath);
            }
        }
    }
}
