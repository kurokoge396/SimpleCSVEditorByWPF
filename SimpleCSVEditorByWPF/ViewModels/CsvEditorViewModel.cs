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
    /// ヘッダー変換用のインターフェース
    /// </summary>
    public interface IHeaderConverter
    {
        string ConvertHeader(string propertyName);
    }

    /// <summary>
    /// CsvEditorのViewModel
    /// </summary>
    public partial class CsvEditorViewModel : ObservableObject, IHeaderConverter
    {
        /// <summary>
        /// データグリッドのモデルコレクション
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<UserModel> userModels;

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

        public CsvEditorViewModel(IFileDialogService filePathService, IMessageDialogService messageDialogService, ICsvFileService csvFileService)
        {
            _fileDialogService = filePathService;
            _csvFileService = csvFileService;
            _messageDialogService = messageDialogService;
            WeakReferenceMessenger.Default.Register<CsvDataLoadedMessage>(this, (r, m) =>
            {
                UserModels = new ObservableCollection<UserModel>(m.Data);
            });
        }

        /// <summary>
        /// ヘッダー名をDatagridの列名に変換する
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>列名</returns>
        public string ConvertHeader(string propertyName)
        {
            return propertyName switch
            {
                "Id" => "ID",
                "Name" => "名前",
                "Password" => "パスワード",
                "IsDeleted" => "削除フラグ",
                _ => propertyName
            };
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        [RelayCommand]
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

                // 確認用後で消す
                await Task.Delay(600000);

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
