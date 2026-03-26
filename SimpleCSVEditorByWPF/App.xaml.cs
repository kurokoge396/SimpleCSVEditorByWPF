using SimpleCSVEditorByWPF.Models;
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
        {//ここが、コンポジションルート
            base.OnStartup(e);

            // サービスを作成
            var dialogService = new FileDialogService();

            // Modelを作成
            var model = new UserModel();

            // ViewModelを作成（依存性注入）
            var csvReadViewModel = new CsvFileReadViewModel(dialogService);

            // MainWindowを作成し、ViewModelを設定（依存性注入）
            var mainWindow = new MainWindow();
            mainWindow.CsvFileReadView.SetViewModel(csvReadViewModel);

            // ウィンドウを表示
            mainWindow.Show();
        }
    }

}
