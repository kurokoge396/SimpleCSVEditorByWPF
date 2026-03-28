using System.Windows;

namespace SimpleCSVEditorByWPF.Services
{
    /// <summary>
    /// メッセージダイアログサービスのインターフェース
    /// </summary>
    public interface IMessageDialogService
    {
        public void ShowInformation(string message, string title);
        public void ShowWarning(string message, string title);
        public void ShowError(string message, string title);
        public bool ShowConfirm(string message, string title);
    }

    /// <summary>
    /// メッセージダイアログサービス
    /// </summary>
    public class MessageDialogService : IMessageDialogService
    {
        /// <summary>
        /// 情報ダイアログを表示する
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        public void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 警告ダイアログを表示する
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        public void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// エラーダイアログを表示する
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        public void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// 確認ダイアログを表示する
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>>
        /// <returns>true:はいボタン押下、false:いいえボタン押下</returns>
        public bool ShowConfirm(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
