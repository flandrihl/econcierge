﻿using System;
using System.Windows;
using Infrasturcture.TouchLibrary;
using CustomControls.LandMark;

namespace eConciergeClient
{
    public partial class MainWindow
    {
        private bool _skipMallClose;
        void MallUnchecked(object sender, RoutedEventArgs e)
        {
            if (!_skipMallClose)
            {
                LandMarkControl.GetInstance().Close();
                _skipWeatherClose = false;
            }
        }
        
        private void LoadMall()
        {
            FrameworkManager.RegisterElement(MallTool, false, new[] { TouchAction.Tap });
            MallTool.Checked += MallToolChecked;
        }

        void MallToolChecked(object sender, RoutedEventArgs e)
        {
            ShowMall();
        }

        private void ShowMall()
        {
            var control = LandMarkControl.GetInstance();
            var top = canvas.ActualHeight / 2 - (control.Height / 2);
            var left = canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += MallControlClosed;
        }

        void MallControlClosed(object sender, EventArgs e)
        {
            _skipMallClose = true;
            MallTool.IsChecked = false;
        }
    }
}
