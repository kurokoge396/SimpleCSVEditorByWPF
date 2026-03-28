using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SimpleCSVEditorByWPF.Messages;
using SimpleCSVEditorByWPF.Services;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class CsvFileReadViewModel : ObservableObject
    {
        /// <summary>
        /// Csvファイルパス
        /// </summary>
        [ObservableProperty]
        private string csvFilePath;

        /// <summary>
        /// ファイルダイアログサービスインターフェイス
        /// </summary>
        private readonly IFileDialogService _fileDialogService;

        /// <summary>
        /// CSVファイルサービス
        /// </summary>
        private readonly ICsvFileService _csvFileService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePathService"></param>
        public CsvFileReadViewModel(IFileDialogService filePathService, ICsvFileService csvFileService)
        {
            _fileDialogService = filePathService;
            _csvFileService = csvFileService;
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
        public async Task LoadCevFile()
        {
            if (string.IsNullOrEmpty(CsvFilePath))
            {
                return;
            }

            var data = await _csvFileService.LoadUserDataCsvData(CsvFilePath);
            if (data.Any())
            {
                WeakReferenceMessenger.Default.Send(new CsvDataLoadedMessage(data));
            }
        }
    }
}
