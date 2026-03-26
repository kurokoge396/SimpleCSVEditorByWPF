using Microsoft.Win32;

namespace SimpleCSVEditorByWPF.Services
{
    public static class FilePathService
    {
        /// <summary>
        /// ファイル選択ダイアログを表示する
        /// </summary>
        /// <returns>ファイルパス</returns>
        public static string SelectFilePath()
        {
            // ダイアログのインスタンスを生成
            var openFileDialog = new OpenFileDialog();

            // フィルタの設定（例：テキストファイルとすべてのファイル）
            openFileDialog.Filter = "CSVファイル (*.csv)|*.csv";

            // ダイアログを表示し、結果が「OK」の場合のみパスを返す
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            // キャンセルされた場合は空文字（またはnull）を返す
            return string.Empty;
        }

        /// <summary>
        /// ファイル保存ダイアログを表示して、ユーザーが選択した保存先のフルパスを取得するメソッド
        /// </summary>
        /// <returns>ファイルパス</returns>
        public static string GetSaveFilePath()
        {
            // 保存ダイアログのインスタンスを生成
            var saveFileDialog = new SaveFileDialog();

            // 拡張子の設定
            saveFileDialog.Filter = "CSVファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*";

            // デフォルトの拡張子を.csvにする
            saveFileDialog.DefaultExt = "csv";

            // ダイアログを表示
            if (saveFileDialog.ShowDialog() == true)
            {
                // ユーザーが決定したフルパスを返す
                return saveFileDialog.FileName;
            }

            // キャンセルされた場合はnullまたは空文字を返す
            return string.Empty;
        }
    }
}
