using SimpleCSVEditorByWPF.Models;
using SimpleCSVEditorByWPF.Services;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
        /// ファイル選択ボタンのクリックイベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            var path = FilePathService.SelectFilePath();
            if (!string.IsNullOrEmpty(path))
            {
                CsvFilePathTextBox.Text = path;
            }
        }

        /// <summary>
        /// ファイル読み込みボタンのクリックイベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void LoadCevFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CsvFilePathTextBox.Text))
            {
                return;
            }

            UserModels = new BindingList<UserModel>(CsvFileService.LoadUserDataCsvData(CsvFilePathTextBox.Text));
            CsvDataGridView.ItemsSource = UserModels;
        }

        /// <summary>
        /// ヘッダーの自動生成イベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Id":
                    e.Column.Header = "ID";
                    break;
                case "Name":
                    e.Column.Header = "名前";
                    break;
                case "Password":
                    e.Column.Header = "パスワード";
                    break;
                case "IsDeleted":
                    e.Column.Header = "削除フラグ";
                    break;
                default:
                    e.Column.Header = e.PropertyName;
                    break;
            }
        }

        /// <summary>
        /// 保存ボタンのクリックイベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void SaveCsvFileButton_Click(object sender, RoutedEventArgs e)
        {
            // 1. 保存先パスを取得
            string filePath = FilePathService.GetSaveFilePath();

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
                MessageBox.Show("保存が完了しました");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存エラー: {ex.Message}");
            }
        }
    }
}