using SimpleCSVEditorByWPF.Models;

namespace SimpleCSVEditorByWPF.Messages
{
    public class CsvDataLoadedMessage
    {
        public List<UserModel> Data { get; }

        public CsvDataLoadedMessage(List<UserModel> data)
        {
            Data = data;
        }
    }
}
