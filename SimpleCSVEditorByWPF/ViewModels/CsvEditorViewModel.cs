using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SimpleCSVEditorByWPF.Messages;
using SimpleCSVEditorByWPF.Models;
using SimpleCSVEditorByWPF.Services;
using System.Collections.ObjectModel;
using System.IO;

namespace SimpleCSVEditorByWPF.ViewModels
{
    /// <summary>
    /// CsvEditorのViewModel
    /// </summary>
    public partial class CsvEditorViewModel : ObservableRecipient, IRecipient<CsvDataLoadedMessage>
    {
        /// <summary>
        /// データグリッドのモデルコレクション
        /// </summary>
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCsvFileCommand))]
        private ObservableCollection<UserModel> userModels;

        /// <summary>
        /// CSVファイルを保存できるかどうかのフラグ
        /// </summary>
        /// <returns>true:保存できる、false:保存できない</returns>
        private bool CanSaveCsvFile() => UserModels != null && (UserModels.Count > 0 || UserModels.Any(u => u.IsAnyRecord()));

        /// <summary>
        /// フォームを閉じるかどうかのフラグ
        /// </summary>
        [ObservableProperty]
        private bool shouldClose;

        /// <summary>
        /// ファイルダイアログサービスインターフェイス
        /// </summary>
        private readonly IFileDialogService _fileDialogService;

        /// <summary>
        /// CSVファイルサービスインターフェイス
        /// </summary>
        private readonly ICsvFileService _csvFileService;

        /// <summary>
        /// メッセージダイアログサービスインターフェイス
        /// </summary>
        private readonly IMessageDialogService _messageDialogService;

        /// <summary>
        /// ヘッダー変換サービスインターフェイス
        /// </summary>
        private readonly IHeaderConvertService _headerConvertService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePathService">ファイルパスサービス</param>
        /// <param name="messageDialogService">メッセージダイアログサービス</param>
        /// <param name="csvFileService">CSVファイルサービス</param>
        /// <param name="headerConvertService">ヘッダー変換サービス</param>
        public CsvEditorViewModel(IFileDialogService filePathService,
                                  IMessageDialogService messageDialogService,
                                  ICsvFileService csvFileService,
                                  IHeaderConvertService headerConvertService)
        {
            _fileDialogService = filePathService;
            _csvFileService = csvFileService;
            _messageDialogService = messageDialogService;
            _headerConvertService = headerConvertService;

            IsActive = true;
        }

        /// <summary>
        /// CSVデータが読み込まれたときの処理
        /// </summary>
        /// <param name="message"></param>
        public void Receive(CsvDataLoadedMessage message)
        {
            UserModels = new ObservableCollection<UserModel>(message.Data);
        }

        /// <summary>
        /// ヘッダー変換用のデリゲート
        /// </summary>
        public Func<string, string> HeaderConverter => _headerConvertService.ConvertHeader;

        /// <summary>
        /// 保存処理
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanSaveCsvFile))]
        public async Task SaveCsvFileAsync()
        {
            if (UserModels == null || !UserModels.Any())
            {
                _messageDialogService.ShowWarning("保存するデータがありません。", "警告");
                return;
            }

            var filePath = _fileDialogService.GetSaveFilePath();

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            else if (File.Exists(filePath))
            {
                // 「いいえ」を選択した場合（false）にreturnで中断する
                if (!_messageDialogService.ShowConfirm("同名のファイルが既に存在します。上書き保存しますか？", "確認"))
                {
                    return;
                }
            }

            try
            {
                WeakReferenceMessenger.Default.Send(new BusyMessage(false));
                await _csvFileService.SaveUserDataCsvData(filePath, UserModels.ToList());
                _messageDialogService.ShowInformation("保存が完了しました", "CSV読み込みくん");
                ShouldClose = true;
            }
            catch (Exception ex)
            {
                _messageDialogService.ShowError($"保存エラー: {ex.Message}", "CSV読み込みくん");
            }
            finally
            {
                WeakReferenceMessenger.Default.Send(new BusyMessage(true));
            }
        }
    }
}
