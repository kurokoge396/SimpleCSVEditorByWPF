using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleCSVEditorByWPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public CsvFileReadViewModel CsvFileReadVM { get; }

        public MainWindowViewModel(CsvFileReadViewModel csvFileReadVM)
        {
            CsvFileReadVM = csvFileReadVM;
        }
    }
}
