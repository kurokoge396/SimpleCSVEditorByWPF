using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public CsvFileReadViewModel CsvFileReadVM { get; }
        public CsvEditorViewModel CsvEditorVM { get; }

        public MainWindowViewModel(CsvFileReadViewModel csvFileReadVM, CsvEditorViewModel csvEditorVM)
        {
            CsvFileReadVM = csvFileReadVM;
            CsvEditorVM = csvEditorVM;
        }
    }
}
