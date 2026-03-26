using SimpleCSVEditorByWPF.Models;
using SimpleCSVEditorByWPF.Services;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace SimpleCSVEditorByWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// ユーザーデータのリストを保持するプロパティ
        /// </summary>
        public BindingList<UserModel> UserModels = new BindingList<UserModel>();

        public MainWindow()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 保存ボタンのクリックイベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void SaveCsvFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (!UserModels.Any())
            {
                MessageBox.Show("保存するデータがありません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //var filePath = FileDialogService.GetSaveFilePath();
            var filePath = string.Empty;

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            else if (File.Exists(filePath))
            {
                var msg = MessageBox.Show("同名のファイルが既に存在します。上書き保存しますか？", "確認", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (msg == MessageBoxResult.No)
                {
                    return;
                }
            }

            try
            {
                CsvFileService.SaveUserDataCsvData(filePath, UserModels.ToList());
                MessageBox.Show("保存が完了しました", "CSV読み込みくん", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存エラー: {ex.Message}");
            }
        }
    }
}