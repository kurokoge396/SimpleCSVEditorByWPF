namespace SimpleCSVEditorByWPF.Services
{
    /// <summary>
    /// ヘッダー変換用のインターフェース
    /// </summary>
    public interface IHeaderConvertService
    {
        /// <summary>
        /// ヘッダー名をDatagridの列名に変換する
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>列名</returns>
        public string ConvertHeader(string propertyName);
    }

    /// <summary>
    /// ヘッダー変換用のサービス
    /// </summary>
    public class HeaderConvertService : IHeaderConvertService
    {
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
    }
}
