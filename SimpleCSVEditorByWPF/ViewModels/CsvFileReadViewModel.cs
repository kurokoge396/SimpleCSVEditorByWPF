using CommunityToolkit.Mvvm.ComponentModel;
using SimpleCSVEditorByWPF.Services;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class CsvFileReadViewModel : ObservableObject
    {
        [ObservableProperty]
        private string csvFilePath;

        private readonly IFileDialogService _fileDialogService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePathService"></param>
        public CsvFileReadViewModel(IFileDialogService filePathService)
        {
            _fileDialogService = filePathService;
        }
    }
}
