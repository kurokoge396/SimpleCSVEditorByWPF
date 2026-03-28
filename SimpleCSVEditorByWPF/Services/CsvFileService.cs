using CsvHelper;
using SimpleCSVEditorByWPF.Models;
using System.Globalization;
using System.IO;
using System.Text;

namespace SimpleCSVEditorByWPF.Services
{
    /// <summary>
    /// CSVファイルサービスのインターフェイス
    /// </summary>
    public interface ICsvFileService
    {
        Task<List<UserModel>> LoadUserDataCsvData(string filePath);
        Task SaveUserDataCsvData(string filePath, List<UserModel> userData);
    }

    /// <summary>
    /// CSVファイルの読み書きを行うサービスクラス
    /// </summary>
    public class CsvFileService : ICsvFileService
    {
        /// <summary>
        /// CSVファイルからユーザーデータを読み込むメソッド
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>ユーザーデータリスト</returns>
        public async Task<List<UserModel>> LoadUserDataCsvData(string filePath)
        {
            return await Task.Run(() =>
             {
                 using (var reader = new StreamReader(filePath, Encoding.UTF8))
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
                         return new List<UserModel>();
                     }
                 }
             });
        }

        /// <summary>
        /// ファイルパスとユーザーデータリストを受け取り、CSVファイルに保存するメソッド
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="userData">ユーザーデータ</param>
        public async Task SaveUserDataCsvData(string filePath, List<UserModel> userData)
        {
            await Task.Run(() =>
            {
                using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<UserModelMap>();
                        csv.WriteRecords(userData);
                    }
                }
            });
        }
    }
}
