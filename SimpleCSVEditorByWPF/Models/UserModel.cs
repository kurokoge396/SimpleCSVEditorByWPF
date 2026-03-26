using CsvHelper.Configuration;

namespace SimpleCSVEditorByWPF.Models
{
    /// <summary>
    /// ユーザーモデル
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public int IsDeleted { get; set; }
    }

    /// <summary>
    /// ユーザーモデルのマッピングクラス
    /// </summary>
    public class UserModelMap : ClassMap<UserModel>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserModelMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Password).Index(2);
            Map(m => m.IsDeleted).Index(3);
        }
    }
}
