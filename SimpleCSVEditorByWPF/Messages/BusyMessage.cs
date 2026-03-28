namespace SimpleCSVEditorByWPF.Messages
{
    /// <summary>
    /// Busyのメッセージ
    /// </summary>
    public class BusyMessage
    {
        /// <summary>
        /// 処理中かどうか
        /// </summary>
        public bool IsViewEnabled { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isViewEnabled">処理状態</param>
        public BusyMessage(bool isViewEnabled) => IsViewEnabled = isViewEnabled;
    }
}
