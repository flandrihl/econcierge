using System;
using System.Windows;
using CustomControls.LandMark;
using eConcierge.Model;
using Infrasturcture.TouchLibrary;
using TouchControls;
using Application = System.Windows.Forms.Application;

namespace eConciergeClient
{
    public partial class MainWindow
    {
        private bool _skipLandmarkClose;
        void LandMarkUnchecked(object sender, RoutedEventArgs e)
        {
            if (!_skipLandmarkClose)
            {
                LandMarkControl.GetInstance().Close();
                _skipLandmarkClose = false;
            }
        }
        
        private void LoadLandMark()
        {
            FrameworkManager.RegisterElement(LandMarkTool, false, new[] { TouchAction.Tap });
            LandMarkTool.Checked += LandMarkToolChecked;
        }

        void LandMarkToolChecked(object sender, RoutedEventArgs e)
        {
            ShowLandMark();
        }

        private void ShowLandMark()
        {
            var control = LandMarkControl.GetInstance();
            var top = canvas.ActualHeight / 2 - (control.Height / 2);
            var left = canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += LandMarkControlClosed;
            control.ShowDirections += ControlShowDirections;
        }

        void ControlShowDirections(object sender, Infrasturcture.Global.Helpers.Events.DataEventArgs e)
        {
            var size = (canvas.ActualHeight < canvas.ActualWidth ? canvas.ActualHeight : canvas.ActualWidth) - 150;
            var path = string.Format("file://{0}/{1}", Application.StartupPath, "mapbackend.html");
            var left = (Width / 2) - (size / 2);
            _mapBrowser = new MapBrowser(path, size, size, ((DTOPointOfInterest)e.Data).Latitude, ((DTOPointOfInterest)e.Data).Longitude);
            _mapBrowser.Load(FrameworkManager, left, 50);
            _mapBrowser.MenuChecked += MapMenuButtonChecked;
            _mapBrowser.MenuUnChecked += MapMenuButtonUnchecked;
            _mapBrowser.Closed += MapBrowserClosed;
        }

        void LandMarkControlClosed(object sender, EventArgs e)
        {
            _skipLandmarkClose = true;
            LandMarkTool.IsChecked = false;
        }
    }
}
