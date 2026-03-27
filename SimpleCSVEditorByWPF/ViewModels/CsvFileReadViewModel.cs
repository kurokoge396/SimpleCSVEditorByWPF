using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleCSVEditorByWPF.Services;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class CsvFileReadViewModel : ObservableObject
    {
        [ObservableProperty]
        private string csvFilePath;

        private readonly IFileDialogService _fileDialogService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePathService"></param>
        public CsvFileReadViewModel(IFileDialogService filePathService)
        {
            _fileDialogService = filePathService;
        }

        /// <summary>
        /// ファイル選択ダイアログを表示し、選択されたファイルパスをCsvFilePathプロパティに設定する
        /// </summary>
        [RelayCommand]
        public void SelectFile()
        {
            var path = _fileDialogService.SelectFilePath();
            if (!string.IsNullOrEmpty(path))
            {
                CsvFilePath = path;
            }
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        [RelayCommand]
        public void LoadCevFile()
        {
            if (string.IsNullOrEmpty(CsvFilePath))
            {
                return;
            }

            //UserModels = new BindingList<UserModel>(CsvFileService.LoadUserDataCsvData(CsvFilePathTextBox.Text));
            //CsvDataGridView.ItemsSource = UserModels;
        }
    }
}
