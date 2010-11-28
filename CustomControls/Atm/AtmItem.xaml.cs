using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using eConcierge.Model;
using Infrasturcture;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Atm
{
    /// <summary>
    /// Interaction logic for TouchOptionItem.xaml
    /// </summary>
    public partial class AtmItem : UserControl, IMTouchControl
    {
        public DTOATM Atm { get; set; }
        public IMTContainer Container { get; set; }
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public event EventHandler Click;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; } 
        public AtmItem(DTOATM atm)
        {
            Atm = atm;
            InitializeComponent();
            DataContext = this;
            Picture = WpfUtil.BytesToImageSource(Atm.Photo);
            Title = Atm.Title;
            Latitude = Atm.Latitude;
            Longitude = Atm.Longitude;
        }

        public void Tapped()
        {
            if(Click!=null)
                Click(this,new EventArgs());
        }
    }
}
