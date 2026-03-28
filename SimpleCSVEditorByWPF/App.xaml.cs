using SimpleCSVEditorByWPF.Services;
using SimpleCSVEditorByWPF.ViewModels;
using System.Windows;

namespace SimpleCSVEditorByWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // サービスを作成
            var dialogService = new FileDialogService();

            // ViewModelを作成（依存性注入）
            var csvReadViewModel = new CsvFileReadViewModel(dialogService);
            var csvEditorViewModel = new CsvEditorViewModel(dialogService);
            var mainWindowViewModel = new MainWindowViewModel(csvReadViewModel, csvEditorViewModel);

            // MainWindowを作成し、ViewModelを設定（依存性注入）
            var mainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };

            // ウィンドウを表示
            mainWindow.Show();
        }
    }
}
