using CsvHelper;
using SimpleCSVEditorByWPF.Models;
using System.IO;

namespace SimpleCSVEditorByWPF.Services
{
    public static class CsvFileService
    {
        public static List<UserModel> LoadUserDataCsvData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
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

        public static void SaveUserDataCsvData(string filePath, List<UserModel> userData)
        {
            using (var writer = new StreamWriter(filePath))
            {
                using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<UserModelMap>();
                    csv.WriteRecords(userData);
                }
            }
        }
    }
}
