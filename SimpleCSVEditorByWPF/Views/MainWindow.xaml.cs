using Microsoft.Win32;
using SimpleCSVEditorByWPF.Models;
using SimpleCSVEditorByWPF.Services;
using System.ComponentModel;
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
        /// ファイル選択ボタンのクリックイベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            var path = SelectFilePath();
            if (!string.IsNullOrEmpty(path))
            {
                CsvFilePathTextBox.Text = path;
            }
        }

        /// <summary>
        /// ファイル選択ダイアログを表示する
        /// </summary>
        /// <returns>ファイルパス</returns>
        public string SelectFilePath()
        {
            // ダイアログのインスタンスを生成
            var openFileDialog = new OpenFileDialog();

            // フィルタの設定（例：テキストファイルとすべてのファイル）
            openFileDialog.Filter = "CSVファイル (*.csv)|*.csv";

            // ダイアログを表示し、結果が「OK」の場合のみパスを返す
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            // キャンセルされた場合は空文字（またはnull）を返す
            return string.Empty;
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
    }
}