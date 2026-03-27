using SimpleCSVEditorByWPF.ViewModels;
using System.Windows.Controls;

namespace SimpleCSVEditorByWPF.Views
{
    /// <summary>
    /// CsvEditorView.xaml の相互作用ロジック
    /// </summary>
    public partial class CsvEditorView : UserControl
    {
        public CsvEditorView()
        {
            InitializeComponent();
        }

        public void SetViewModel(CsvEditorViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}
