using System;
using System.Windows;
using CustomControls.Cafe;
using Infrasturcture.TouchLibrary;

namespace eConciergeClient
{
    public partial class MainWindow
    {
        private bool _skipCafeClose;
        void CafeUnchecked(object sender, RoutedEventArgs e)
        {
            if (!_skipCafeClose)
            {
                CafeControl.GetInstance().Close();
                _skipWeatherClose = false;
            }
        }
        
        private void LoadCafe()
        {
            FrameworkManager.RegisterElement(CafeTool, false, new[] { TouchAction.Tap });
            CafeTool.Checked += CafeToolChecked;
        }

        void CafeToolChecked(object sender, RoutedEventArgs e)
        {
            ShowCafe();
        }

        private void ShowCafe()
        {
            var control = CafeControl.GetInstance();
            var top = canvas.ActualHeight / 2 - (control.Height / 2);
            var left = canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += CafeControlClosed;
            control.ShowDirections += ControlShowDirections;
        }

        void CafeControlClosed(object sender, EventArgs e)
        {
            _skipCafeClose = true;
            CafeTool.IsChecked = false;
        }
    }
}
