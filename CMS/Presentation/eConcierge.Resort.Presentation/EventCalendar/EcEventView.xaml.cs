using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using eConcierge.Foundation.Presenters;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Presentation.EventCalendar
{
    /// <summary>
    /// Interaction logic for EcEventView.xaml
    /// </summary>
    [Export(typeof(IECEventView))]
    public partial class EcEventView : IECEventView
    {
        public EcEventView()
        {
            InitializeComponent();
        }
        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}
