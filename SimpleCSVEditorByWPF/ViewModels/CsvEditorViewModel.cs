using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleCSVEditorByWPF.Models;
using SimpleCSVEditorByWPF.Services;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class CsvEditorViewModel : ObservableObject
    {
        [ObservableProperty]
        private BindingList<UserModel> userModels;

        /// <summary>
        /// 保存処理
        /// </summary>
        [RelayCommand]
        public void SaveCsvFile()
        {
            if (!UserModels.Any())
            {
                MessageBox.Show("保存するデータがありません。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //var filePath = FileDialogService.GetSaveFilePath();
            var filePath = string.Empty;

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            else if (File.Exists(filePath))
            {
                var msg = MessageBox.Show("同名のファイルが既に存在します。上書き保存しますか？", "確認", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (msg == MessageBoxResult.No)
                {
                    return;
                }
            }

            try
            {
                CsvFileService.SaveUserDataCsvData(filePath, UserModels.ToList());
                MessageBox.Show("保存が完了しました", "CSV読み込みくん", MessageBoxButton.OK, MessageBoxImage.Information);
                //Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存エラー: {ex.Message}");
            }
        }
    }
}
