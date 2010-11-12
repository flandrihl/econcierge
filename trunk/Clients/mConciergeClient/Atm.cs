using System;
using System.Windows;
using CustomControls.Atm;
using Infrasturcture.TouchLibrary;

namespace eConciergeClient
{
    public partial class MainWindow
    {
        private bool _skipAtmClose;
        void AtmUnchecked(object sender, RoutedEventArgs e)
        {
            if (!_skipAtmClose)
            {
                AtmControl.GetInstance().Close();
                _skipAtmClose = false;
            }
        }
        
        private void LoadAtm()
        {
            FrameworkManager.RegisterElement(AtmTool, false, new[] { TouchAction.Tap });
            AtmTool.Checked += AtmToolChecked;
        }

        void AtmToolChecked(object sender, RoutedEventArgs e)
        {
            ShowAtm();
        }

        private void ShowAtm()
        {
            var control = AtmControl.GetInstance();
            var top = canvas.ActualHeight / 2 - (control.Height / 2);
            var left = canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += AtmControlClosed;
        }

        void AtmControlClosed(object sender, EventArgs e)
        {
            _skipAtmClose = true;
            AtmTool.IsChecked = false;
        }
    }
}
