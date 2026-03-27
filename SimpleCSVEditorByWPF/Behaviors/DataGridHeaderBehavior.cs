using Microsoft.Xaml.Behaviors;
using SimpleCSVEditorByWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCSVEditorByWPF.Behaviors
{
    /// <summary>
    /// データグリッドのヘッダーのビヘイビアー
    /// </summary>
    public class DataGridHeaderBehavior : Behavior<DataGrid>
    {
        /// <summary>
        /// ヘッダー変換用の関数
        /// </summary>
        public Func<string, string>? HeaderConverter
        {
            get { return (Func<string, string>?)GetValue(HeaderConverterProperty); }
            set { SetValue(HeaderConverterProperty, value); }
        }

        /// <summary>
        /// ヘッダー変換用の関数の依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty HeaderConverterProperty =
            DependencyProperty.Register(
                nameof(HeaderConverter),
                typeof(Func<string, string>),
                typeof(DataGridHeaderBehavior),
                new PropertyMetadata(null));

        /// <summary>
        /// ビヘイビアーがアタッチされたときの処理
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AutoGeneratingColumn += OnAutoGeneratingColumn;
        }

        /// <summary>
        /// ビヘイビアーがデタッチされたときの処理
        /// メモリリーク・イベント残留防止のため、イベントハンドラーを解除する
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.AutoGeneratingColumn -= OnAutoGeneratingColumn;
            base.OnDetaching();
        }

        /// <summary>
        /// ヘッダーの自動生成イベントのハンドラー
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (AssociatedObject.DataContext is IHeaderConverter converter)
            {
                e.Column.Header = converter.ConvertHeader(e.PropertyName);
            }
        }
    }
}
