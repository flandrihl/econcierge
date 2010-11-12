using System;
using System.Windows;
using CustomControls.LandMark;
using Infrasturcture.TouchLibrary;

namespace mConciergeClient
{
    public partial class MainWindow
    {
        private bool _skipCafeClose;
        void CafeUnchecked(object sender, RoutedEventArgs e)
        {
            if (!_skipCafeClose)
            {
                LandMarkControl.GetInstance().Close();
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
            var control = LandMarkControl.GetInstance();
            var top = canvas.ActualHeight / 2 - (control.Height / 2);
            var left = canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += CafeControlClosed;
        }

        void CafeControlClosed(object sender, EventArgs e)
        {
            _skipCafeClose = true;
            CafeTool.IsChecked = false;
        }
    }
}
