using System.Windows;
using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Shell
{
    public class MainWindowPresenter:APresenter
    {
        private readonly eConciergeBootstrapper _bootstrapper;

        public MainWindowPresenter(IView view)
            : base(view)
        {
            _bootstrapper = CreateBootstrapper();
            _bootstrapper.Run();
            ShellPresenter = _bootstrapper.GetShell();
        }

        private static eConciergeBootstrapper CreateBootstrapper()
        {
            return new eConciergeBootstrapper();
        }
        public static readonly DependencyProperty ShellPresenterProperty = DependencyProperty.Register(
            "ShellPresenter",
            typeof(ShellPresenter),
            typeof(MainWindowPresenter));

        public ShellPresenter ShellPresenter
        {
            get
            {
                return (ShellPresenter)GetValue(ShellPresenterProperty);
            }
            set
            {
                SetValue(ShellPresenterProperty, value);
            }
        }
    }
}
