using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls.Primitives;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Presentation.Views
{
    /// <summary>
    /// Interaction logic for DialogControl.xaml
    /// </summary>
    [Export(typeof(IDialogView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class DialogView : IDialogView
    {
        public DialogView()
        {
            InitializeComponent();
        }

        #region IView Members

        public IPresenter Presenter
        {
            set 
            {
                DataContext = value;
            }
        }

        #endregion

        private void MoveThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        public void SetMainWindowAsOwner()
        {
            Owner = Application.Current.MainWindow;
        }

    }
}
