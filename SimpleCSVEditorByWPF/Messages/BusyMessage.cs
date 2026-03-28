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
        public bool IsBusy { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isBusy">処理状態</param>
        public BusyMessage(bool isBusy) => IsBusy = isBusy;
    }
}
