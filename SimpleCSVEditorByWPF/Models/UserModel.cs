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
        //[Index(0)]
        public string Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        //[Index(1)]
        public string Name { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        //[Index(2)]
        public string Password { get; set; }

        /// <summary>
        /// 削除フラグ
        /// </summary>
        //[Index(3)]
        public int IsDeleted { get; set; }
    }

    /// <summary>
    /// ユーザーモデルのマッピングクラス
    /// </summary>
    public class UserModelMap : ClassMap<UserModel>
    {
        public UserModelMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Password).Index(2);
            Map(m => m.IsDeleted).Index(3);
        }
    }
}
