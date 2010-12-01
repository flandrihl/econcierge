using System;
using System.Windows;
using System.Windows.Controls;
using CustomControls.InheritedFrameworkControls;
using Infrasturcture.TouchLibrary;

namespace CustomControls.CalendarControl
{
    /// <summary>
    /// Interaction logic for DayItem.xaml
    /// </summary>
    public partial class CalendarDayItem : UserControl, IMTouchControl
    {
        public event EventHandler Click;
        public IMTContainer Container { get; set; }

        public CalendarDayItem(double fontRatio)
        {
            InitializeComponent();
            FontRatio = fontRatio;
            DayButton.Click += DayButtonClick;
        }

        void DayButtonClick(object sender, RoutedEventArgs e)
        {
            if (Click != null)
                Click(sender, e);
        }

        public TouchRadioButton DayButton
        {
            get { return btn; }
        }

        public double FontRatio { get; set; }

        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {
            btn.FontSize = Height / FontRatio;
        }
    }
}
