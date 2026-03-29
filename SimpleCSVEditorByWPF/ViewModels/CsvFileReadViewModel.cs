using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SimpleCSVEditorByWPF.Messages;
using SimpleCSVEditorByWPF.Services;
using System.IO;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class CsvFileReadViewModel : ObservableObject
    {
        /// <summary>
        /// Csvファイルパス
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoadCsvFileCommand))]
        private string csvFilePath;

        /// <summary>
        /// CSVファイルが選択されているかどうか
        /// </summary>
        /// <returns>true:テキストボックスのファイルパス正常、false:不正</returns>
        private bool CanLoadCsvFile() => !string.IsNullOrEmpty(CsvFilePath) && File.Exists(CsvFilePath) && Path.GetExtension(CsvFilePath) == ".csv";

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
        [RelayCommand(CanExecute = nameof(CanLoadCsvFile))]
        public async Task LoadCsvFileAsync()
        {
            var data = await _csvFileService.LoadUserDataCsvData(CsvFilePath);
            if (data.Any())
            {
                WeakReferenceMessenger.Default.Send(new CsvDataLoadedMessage(data));
            }
        }
    }
}
