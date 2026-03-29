using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SimpleCSVEditorByWPF.Messages;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableRecipient, IRecipient<BusyMessage>
    {
        /// <summary>
        /// CsvFileReadViewModelのインスタンス
        /// </summary>
        public CsvFileReadViewModel CsvFileReadVM { get; }

        /// <summary>
        /// CsvEditorViewModelのインスタンス
        /// </summary>
        public CsvEditorViewModel CsvEditorVM { get; }

        /// <summary>
        /// 活性非活性管理用プロパティ
        /// </summary>
        [ObservableProperty]
        private bool isViewEnabled = true;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="csvFileReadVM"> CsvFileReadViewModelのインスタンス</param>
        /// <param name="csvEditorVM">CsvEditorViewModelのインスタンス</param>
        public MainWindowViewModel(CsvFileReadViewModel csvFileReadVM, CsvEditorViewModel csvEditorVM)
        {
            CsvFileReadVM = csvFileReadVM;
            CsvEditorVM = csvEditorVM;

            IsActive = true;
        }

        /// <summary>
        /// BusyMessageを受信したときの処理
        /// </summary>
        /// <param name="message"></param>
        public void Receive(BusyMessage message)
        {
            IsViewEnabled = message.IsViewEnabled;
        }
    }
}