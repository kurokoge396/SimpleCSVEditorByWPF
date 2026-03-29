using CommunityToolkit.Mvvm.Input;
using Microsoft.Xaml.Behaviors;
using System.Collections.Specialized;
using System.Windows;

namespace SimpleCSVEditorByWPF.Behaviors
{
    public class CollectionChangedNotifyBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// コレクションの変更を通知するための依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty CollectionProperty =
        DependencyProperty.Register(
            nameof(Collection),
            typeof(INotifyCollectionChanged),
            typeof(CollectionChangedNotifyBehavior),
            new PropertyMetadata(null, OnCollectionChanged));

        /// <summary>
        /// コレクションの変更を通知するためのプロパティ
        /// </summary>
        public INotifyCollectionChanged? Collection
        {
            get => (INotifyCollectionChanged?)GetValue(CollectionProperty);
            set => SetValue(CollectionProperty, value);
        }

        /// <summary>
        /// コレクションの変更を通知するためのコマンドの依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(IRelayCommand),
                typeof(CollectionChangedNotifyBehavior),
                new PropertyMetadata(null));

        /// <summary>
        /// コレクションの変更を通知するためのコマンド
        /// </summary>
        public IRelayCommand? Command
        {
            get => (IRelayCommand?)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        /// コレクションの変更を通知するためのコレクションが変更されたときの処理
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (CollectionChangedNotifyBehavior)d;

            if (e.OldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= behavior.OnCollectionChangedInternal;
            }

            if (e.NewValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += behavior.OnCollectionChangedInternal;
            }
        }

        /// <summary>
        /// コレクションの変更を通知するためのコレクションが変更されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCollectionChangedInternal(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Command?.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// ビヘイビアーがデタッチされたときの処理
        /// </summary>
        protected override void OnDetaching()
        {
            if (Collection != null)
            {
                Collection.CollectionChanged -= OnCollectionChangedInternal;
            }
            base.OnDetaching();
        }
    }
}
