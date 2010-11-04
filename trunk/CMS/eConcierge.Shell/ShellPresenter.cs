using System.ComponentModel.Composition;
using System.Windows;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Shell
{
    [Export(typeof(ShellPresenter))]
    public class ShellPresenter:APresenter
    {
        [ImportingConstructor]
        public ShellPresenter(ShellView view) : base(view)
        {
            Application.Current.MainWindow.SizeChanged += HandleSizeChanged;
        }
        private void HandleSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ShellHeight = Application.Current.MainWindow.ActualHeight - 38;
            ShellWidth = Application.Current.MainWindow.ActualWidth - 16;
        }
        public static readonly DependencyProperty ShellHeightProperty = DependencyProperty.Register(
            "ShellHeight",
            typeof(double),
            typeof(ShellPresenter));
        public double ShellHeight
        {
            get
            {
                return (double)GetValue(ShellHeightProperty);
            }
            set
            {
                SetValue(ShellHeightProperty, value);
            }
        }
        public static readonly DependencyProperty ShellWidthProperty = DependencyProperty.Register(
            "ShellWidth",
            typeof(double),
            typeof(ShellPresenter));
        public double ShellWidth
        {
            get
            {
                return (double)GetValue(ShellWidthProperty);
            }
            set
            {
                SetValue(ShellWidthProperty, value);
            }
        }
    }
}
