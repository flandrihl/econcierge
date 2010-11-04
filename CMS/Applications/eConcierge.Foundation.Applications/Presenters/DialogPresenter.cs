using System;
using System.ComponentModel.Composition;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Input;
using eConcierge.Foundation.Applications.Commands;
using eConcierge.Foundation.Applications.EventArguments;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.Presenters
{
    [Export(typeof(DialogPresenter))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DialogPresenter:APresenter
    {


        public bool AllowTransparency
        {
            get { return (bool)GetValue(AllowTransparencyProperty); }
            set { SetValue(AllowTransparencyProperty, value); }
        }

        public static readonly DependencyProperty AllowTransparencyProperty =
            DependencyProperty.Register("AllowTransparency", typeof(bool), typeof(DialogPresenter), new UIPropertyMetadata(true));


        private bool _isOkayButtonEnabled = true;
        public bool IsOkayButtonEnabled 
        { 
            get
            {
                return _isOkayButtonEnabled;
            } 
            set
            {
                _isOkayButtonEnabled = value;
                DialogCommand.RaiseCanExecuteChanged();
            }
        }
        [ImportingConstructor]
        public DialogPresenter(IDialogView view)
            :base(view)
        {
            _view = view;
            DialogCommand = new DelegateCommand(ExecuteCommand,CanExecuteCommand);
            _view.Activated += PopupContainerActivated;
            _view.KeyDown += PopupContainerKeyDown;
            SetButtonContentProperties();
        }

        void PopupContainerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Escape) return;
            if (DialogResult == DialogResult.Cancel) return;
            e.Handled = true;
            CloseDialog();
            DialogResult = DialogResult.Cancel;
        }

        private bool CanExecuteCommand(object arg)
        {
            return (DialogResult)arg != DialogResult.OK || IsOkayButtonEnabled;
        }


        void PopupContainerActivated(object sender, EventArgs e)
        {
            DialogContentPresenter.OnActivated();
        }

        private void SetButtonContentProperties()
        {
            YesButtonCaption = "Yes";
            NoButtonCaption = "No";
            OkButtonCaption = "Ok";
            CancelButtonCaption = "Cancel";
            IgnoreButtonCaption = "Ignore";
            AbortButtonCaption = "Abort";
            RetryButtonCaption = "Retry";
        }

        public DelegateCommand DialogCommand { get; set; }

        private void ExecuteCommand(object parameter)
        {
            DialogResult = (DialogResult)parameter;
            if (DialogContentPresenter == null)
            {
                _view.Close();
                SetValue(UserViewProperty, null);
            }
            else if (DialogContentPresenter.OnClosing(DialogResult))
            {
                _view.Close();
                SetValue(UserViewProperty, null);
            }
        }

        #region IDialogPresenter Members

        public DialogResult ShowModal(ADialogContentPresenter presenter)
        {
            return Show(presenter, "", DialogButton.None, true);
        }

        public ADialogContentPresenter DialogContentPresenter { get; set; }

        private DialogResult Show(ADialogContentPresenter presenter, string title, DialogButton dialogButton, bool isModal)
        {
            DialogContentPresenter = presenter;

            _view.SetMainWindowAsOwner();

            if(IsMouseCaptureOn)
            {
                CaptureOnElement = View as UIElement;
                SetMouseCaptureOn();
            }
            DialogContentPresenter = presenter;
            presenter.DialogResultEvent += DialogContainerPresenterDialogResultEvent;

            SetProperties(presenter.View, title, dialogButton);

            presenter.OnShowing();

            if (isModal)
            {
                _view.ShowDialog();
                SetValue(UserViewProperty, null);
                SetMouseCaptureOff();
            }
            else
                _view.Show();

            return DialogResult;
        }

        #region Mouse Capture
        private UIElement CaptureOnElement { set; get; }
        private void SetMouseCaptureOn()
        {
            if (CaptureOnElement == null) return;

            var uiView = CaptureOnElement;            
            uiView.PreviewMouseDown += ViewPreviewMouseDown;
            uiView.MouseLeave += ViewMouseLeave;
            uiView.MouseWheel += ViewMouseWheel;
            Mouse.Capture(uiView, CaptureMode.SubTree);
        }

        private void SetMouseCaptureOff()
        {
            if (CaptureOnElement == null) return;
            var uiView = CaptureOnElement;
            uiView.PreviewMouseDown -= ViewPreviewMouseDown;
            uiView.MouseLeave -= ViewMouseLeave;
            uiView.MouseWheel -= ViewMouseWheel;
            Mouse.Capture(null);
            CaptureOnElement = null;
        }

        private static void ViewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void ViewMouseLeave(object sender, MouseEventArgs e)
        {
            if (CaptureOnElement == null)
                return;
            if (IsMouseCaptureOn)
            {
                if (Mouse.Captured != CaptureOnElement)
                    Mouse.Capture(CaptureOnElement, CaptureMode.SubTree);
            }
        }
        private static bool IsInViewArea(Point point, Size renderSize)
        {
            var rect = new Rect(new Point(0, 0), renderSize);
            return rect.Contains(point);
        }
        private void ViewPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(CaptureOnElement == null)
                return;
            if (IsMouseCaptureOn)
            {
                Point point = e.GetPosition(CaptureOnElement);
                if (IsInViewArea(point, CaptureOnElement.RenderSize) == false)
                {
                    e.Handled = true;
                }
            }
        }
        
        #endregion
        void DialogContainerPresenterDialogResultEvent(object sender, GenericEventArgs<DialogResult> e)
        {
            DialogResult = e.Data;

            CloseDialog();
        }

        private void CloseDialog()
        {
            if(IsMouseCaptureOn)
                SetMouseCaptureOff();

            if (DialogContentPresenter != null && DialogContentPresenter.OnClosing(DialogResult))
            {
                ClearValue(UserViewProperty);
                _view.Close();
            }
        }

        #endregion

        #region IDialogPresenter Members

        public DialogResult DialogResult { get; private set; }

        #endregion

        public PlacementMode Placement
        {
            get 
            {
                return (PlacementMode) GetValue(PlacementProperty);
            }
            set
            {
                SetValue(PlacementProperty, value);
            }
        }

        public bool IsMouseCaptureOn { set; get; }

        public string YesButtonCaption 
        {
            get
            {
                return GetValue(YesButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(YesButtonCaptionProperty, value);
            }
        }

        public string NoButtonCaption
        {
            get
            {
                return GetValue(NoButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(NoButtonCaptionProperty, value);
            }
        }

        public string OkButtonCaption
        {
            get
            {
                return GetValue(OkButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(OkButtonCaptionProperty, value);
            }
        }

        public string CancelButtonCaption
        {
            get
            {
                return GetValue(CancelButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(CancelButtonCaptionProperty, value);
            }
        }

        public string IgnoreButtonCaption
        {
            get
            {
                return GetValue(IgnoreButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(IgnoreButtonCaptionProperty, value);
            }
        }

        public string AbortButtonCaption
        {
            get
            {
                return GetValue(AbortButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(AbortButtonCaptionProperty, value);
            }
        }

        public string RetryButtonCaption
        {
            get
            {
                return GetValue(RetryButtonCaptionProperty).ToString();
            }
            set
            {
                SetValue(RetryButtonCaptionProperty, value);
            }
        }

        public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register(
            "Placement",
            typeof(PlacementMode),
            typeof(DialogPresenter),
            new PropertyMetadata(PlacementMode.Center)
            );
        public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register(
            "PlacementTarget",
            typeof(UIElement),
            typeof(DialogPresenter)            
            );
        public static readonly DependencyProperty TitlebarVisibilityProperty = DependencyProperty.Register(
            "TitlebarVisibility",
            typeof (Visibility),
            typeof (DialogPresenter),
            new PropertyMetadata(Visibility.Visible)
            );

        public static readonly DependencyProperty YesButtonCaptionProperty = DependencyProperty.Register(
            "YesButtonCaption",
            typeof(string),
            typeof(DialogPresenter));

        public static readonly DependencyProperty NoButtonCaptionProperty = DependencyProperty.Register(
            "NoButtonCaption",
            typeof(string),
            typeof(DialogPresenter));

        public static readonly DependencyProperty OkButtonCaptionProperty = DependencyProperty.Register(
            "OkButtonCaption",
            typeof(string),
            typeof(DialogPresenter));

        public static readonly DependencyProperty CancelButtonCaptionProperty = DependencyProperty.Register(
            "CancelButtonCaption",
            typeof(string),
            typeof(DialogPresenter));

        public static readonly DependencyProperty IgnoreButtonCaptionProperty = DependencyProperty.Register(
            "IgnoreButtonCaption",
            typeof(string),
            typeof(DialogPresenter));

        public static readonly DependencyProperty AbortButtonCaptionProperty = DependencyProperty.Register(
            "AbortButtonCaption",
            typeof(string),
            typeof(DialogPresenter));

        public static readonly DependencyProperty RetryButtonCaptionProperty = DependencyProperty.Register(
            "RetryButtonCaption",
            typeof(string),
            typeof(DialogPresenter));
        public static readonly DependencyProperty UserViewProperty = DependencyProperty.Register(
            "UserView",
            typeof(UIElement),
            typeof(DialogPresenter));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(DialogPresenter));
        public static readonly DependencyProperty CommandPanelVisibilityProperty = DependencyProperty.Register(
            "CommandPanelVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty OkButtonVisibilityProperty = DependencyProperty.Register(
            "OkButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty CancelButtonVisibilityProperty = DependencyProperty.Register(
            "CancelButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty YesButtonVisibilityProperty = DependencyProperty.Register(
            "YesButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty NoButtonVisibilityProperty = DependencyProperty.Register(
            "NoButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty IgnoreButtonVisibilityProperty = DependencyProperty.Register(
            "IgnoreButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty RetryButtonVisibilityProperty = DependencyProperty.Register(
            "RetryButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));
        public static readonly DependencyProperty AbortButtonVisibilityProperty = DependencyProperty.Register(
            "AbortButtonVisibility",
            typeof(Visibility),
            typeof(DialogPresenter));

        private readonly IDialogView _view;

        #region IDialogPresenter Members


        public void Show(ADialogContentPresenter presenter)
        {
            Show(presenter, "", DialogButton.None, false);
        }

        public void Show(ADialogContentPresenter presenter, string title)
        {
            Show(presenter, title, DialogButton.None, false);
        }

        #endregion

        #region IDialogPresenter Members

        public Visibility TitleBarVisibility
        {
            get
            {
                return (Visibility) GetValue(TitlebarVisibilityProperty);
            }
            set 
            { 
                SetValue(TitlebarVisibilityProperty, value);
            }
        }

        public UIElement PlacementTarget
        {
            get
            {
                return (UIElement) GetValue(PlacementTargetProperty);
            }
            set 
            { 
                SetValue(PlacementTargetProperty,value);
            }
        }

        #endregion

        #region IDialogPresenter Members


        public DialogResult ShowModal(IView view)
        {
            return Show(view, "", DialogButton.None, true);
        }

        public DialogResult ShowModal(IView view, string title)
        {
            return Show(view, "", DialogButton.None, true);
        }
        

        public void Show(IView view)
        {
            Show(view, "", DialogButton.None, false);
        }

        public void Show(IView view, string title)
        {
            Show(view, title, DialogButton.None, false);
        }

        public void Show(IView view, string title, bool isModal)
        {
            Show(view, title, DialogButton.None, isModal);
        }
        private DialogResult Show(IView view, string title, DialogButton dialogButton, bool isModal)
        {
            _view.SetMainWindowAsOwner();

            SetProperties(view, title, dialogButton);
            
            if (isModal)
            {
                _view.ShowDialog();
            }
            else
                _view.Show();

            SetValue(UserViewProperty, null);
                
            return DialogResult;
        }

        private void SetProperties(IView view, string title, DialogButton dialogButton)
        {
            SetValue(TitleProperty, title);
            SetValue(UserViewProperty, view);

            SetValue(CommandPanelVisibilityProperty, Visibility.Collapsed);
            SetValue(OkButtonVisibilityProperty, Visibility.Collapsed);
            SetValue(CancelButtonVisibilityProperty, Visibility.Collapsed);
            SetValue(YesButtonVisibilityProperty, Visibility.Collapsed);
            SetValue(NoButtonVisibilityProperty, Visibility.Collapsed);
            SetValue(IgnoreButtonVisibilityProperty, Visibility.Collapsed);
            SetValue(RetryButtonVisibilityProperty, Visibility.Collapsed);
            SetValue(AbortButtonVisibilityProperty, Visibility.Collapsed);

            switch (dialogButton)
            {
                case DialogButton.None:
                    break;
                case DialogButton.OK:
                    SetValue(CommandPanelVisibilityProperty, Visibility.Visible);
                    SetValue(OkButtonVisibilityProperty, Visibility.Visible);
                    break;
                case DialogButton.OKCancel:
                    SetValue(CommandPanelVisibilityProperty, Visibility.Visible);
                    SetValue(OkButtonVisibilityProperty, Visibility.Visible);
                    SetValue(CancelButtonVisibilityProperty, Visibility.Visible);
                    break;
                case DialogButton.AbortRetryIgnore:
                    SetValue(CommandPanelVisibilityProperty, Visibility.Visible);
                    SetValue(AbortButtonVisibilityProperty, Visibility.Visible);
                    SetValue(RetryButtonVisibilityProperty, Visibility.Visible);
                    SetValue(IgnoreButtonVisibilityProperty, Visibility.Visible);
                    break;
                case DialogButton.YesNoCancel:
                    SetValue(CommandPanelVisibilityProperty, Visibility.Visible);
                    SetValue(YesButtonVisibilityProperty, Visibility.Visible);
                    SetValue(NoButtonVisibilityProperty, Visibility.Visible);
                    SetValue(CancelButtonVisibilityProperty, Visibility.Visible);
                    break;
                case DialogButton.YesNo:
                    SetValue(CommandPanelVisibilityProperty, Visibility.Visible);
                    SetValue(YesButtonVisibilityProperty, Visibility.Visible);
                    SetValue(NoButtonVisibilityProperty, Visibility.Visible);
                    break;
                case DialogButton.RetryCancel:
                    SetValue(CommandPanelVisibilityProperty, Visibility.Visible);
                    SetValue(RetryButtonVisibilityProperty, Visibility.Visible);
                    SetValue(CancelButtonVisibilityProperty, Visibility.Visible);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region IDialogPresenter Members

        public DialogResult ShowModal(ADialogContentPresenter presenter, string title)
        {
            return Show(presenter, title, DialogButton.None, true);
        }

        public DialogResult ShowModal(ADialogContentPresenter presenter, string title, DialogButton dialogButton)
        {
            return Show(presenter, title, dialogButton, true);
        }

        public void Show(ADialogContentPresenter presenter, string title, DialogButton dialogButton)
        {
            Show(presenter, title, dialogButton, false);
        }        

        public DialogResult ShowModal(IView view, string title, DialogButton dialogButton)
        {
            return Show(view, title, dialogButton, true);
        }

        public void Show(IView view, string title, DialogButton dialogButton)
        {
            Show(view, title, dialogButton, false);
        }

        #endregion
    }
}
