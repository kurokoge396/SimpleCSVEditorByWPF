using CsvHelper;
using SimpleCSVEditorByWPF.Models;
using System.Globalization;
using System.IO;
using System.Text;

namespace SimpleCSVEditorByWPF.Services
{
    /// <summary>
    /// CSVファイルの読み書きを行うサービスクラス
    /// </summary>
    public static class CsvFileService
    {
        /// <summary>
        /// CSVファイルからユーザーデータを読み込むメソッド
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>ユーザーデータリスト</returns>
        public static List<UserModel> LoadUserDataCsvData(string filePath)
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<UserModelMap>();
                    var records = csv.GetRecords<UserModel>().ToList();
                    if (records.Any())
                    {
                        return records;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// ファイルパスとユーザーデータリストを受け取り、CSVファイルに保存するメソッド
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="userData">ユーザーデータ</param>
        public static void SaveUserDataCsvData(string filePath, List<UserModel> userData)
        {
            using (var writer = new StreamWriter(filePath))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<UserModelMap>();
                    csv.WriteRecords(userData);
                }
            }
        }
    }
}
