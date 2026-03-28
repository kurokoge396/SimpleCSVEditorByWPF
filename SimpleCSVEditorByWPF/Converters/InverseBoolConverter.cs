using System.Globalization;
using System.Windows.Data;

namespace SimpleCSVEditorByWPF.Converters
{
    /// <summary>
    /// コンバーター
    /// </summary>
    public class InverseBoolConverter : IValueConverter
    {
        /// <summary>
        /// 変換
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ</param>
        /// <returns>変換結果</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => !(bool)value;

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ</param>
        /// <returns>変換結果</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => !(bool)value;
    }
}
