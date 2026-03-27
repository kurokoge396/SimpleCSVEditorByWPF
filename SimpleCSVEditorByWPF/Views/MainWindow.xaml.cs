using SimpleCSVEditorByWPF.Models;
using System.ComponentModel;
using System.Windows;

namespace SimpleCSVEditorByWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// ユーザーデータのリストを保持するプロパティ
        /// </summary>
        public BindingList<UserModel> UserModels = new BindingList<UserModel>();

        public MainWindow()
        {
            InitializeComponent();
        }




    }
}