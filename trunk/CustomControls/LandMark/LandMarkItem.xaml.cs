using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CustomControls.InheritedFrameworkControls;
using eConcierge.Model;
using Infrasturcture;
using Infrasturcture.DTO;
using Infrasturcture.TouchLibrary;

namespace CustomControls.LandMark
{
    /// <summary>
    /// Interaction logic for TouchOptionItem.xaml
    /// </summary>
    public partial class LandMarkItem : UserControl, IMTouchControl
    {
        public DTOPointOfInterest LandMark { get; set; }
        public IMTContainer Container { get; set; }
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public event EventHandler Click;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; } 
        public LandMarkItem(DTOPointOfInterest landMark)
        {
            LandMark = landMark;
            InitializeComponent();
            DataContext = this;
            Picture = WpfUtil.BytesToImageSource(landMark.Photo);
            Title = landMark.Title;
            Latitude = landMark.Latitude;
            Longitude = landMark.Longitude;
        }

        public void Tapped()
        {
            if(Click!=null)
                Click(this,new EventArgs());
        }
    }
}
