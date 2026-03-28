namespace SimpleCSVEditorByWPF.TriggerActions
{
    using Microsoft.Xaml.Behaviors;
    using System.Windows;

    public class CloseWindowAction : TriggerAction<FrameworkElement>
    {
        public bool ShouldClose
        {
            get => (bool)GetValue(ShouldCloseProperty);
            set => SetValue(ShouldCloseProperty, value);
        }

        public static readonly DependencyProperty ShouldCloseProperty =
            DependencyProperty.Register(
                nameof(ShouldClose),
                typeof(bool),
                typeof(CloseWindowAction),
                new PropertyMetadata(false, OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                var action = (CloseWindowAction)d;
                var window = Window.GetWindow(action.AssociatedObject);
                window?.Close();
            }
        }

        protected override void Invoke(object parameter)
        {
            // 今回は未使用（プロパティ監視のみ）
        }
    }
}
