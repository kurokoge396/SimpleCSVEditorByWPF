using SimpleCSVEditorByWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCSVEditorByWPF.Views
{
    /// <summary>
    /// CsvFileReadView.xaml の相互作用ロジック
    /// </summary>
    public partial class CsvFileReadView : UserControl
    {
        public CsvFileReadView()
        {
            InitializeComponent();
        }

        public void SetViewModel(CsvFileReadViewModel viewModel)
        {
            DataContext = viewModel;
        }

        /// <summary>
        /// ファイル選択ボタンのクリックイベントハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            //var path = FileDialogService.SelectFilePath();
            //if (!string.IsNullOrEmpty(path))
            //{
            //    CsvFilePathTextBox.Text = path;
            //}
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

            //UserModels = new BindingList<UserModel>(CsvFileService.LoadUserDataCsvData(CsvFilePathTextBox.Text));
            //CsvDataGridView.ItemsSource = UserModels;
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
    }
}
