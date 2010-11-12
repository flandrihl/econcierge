using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Infrasturcture;
using Infrasturcture.DTO;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Atm
{
    /// <summary>
    /// Interaction logic for TouchOptionItem.xaml
    /// </summary>
    public partial class AtmItem : UserControl, IMTouchControl
    {
        public DTOLandMark LandMark { get; set; }
        public IMTContainer Container { get; set; }
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public event EventHandler Click;
        public AtmItem(DTOLandMark landMark)
        {
            LandMark = landMark;
            InitializeComponent();
            DataContext = this;
            Picture = WpfUtil.BytesToImageSource(landMark.Picture);
            Title = landMark.Title;
        }

        public void Tapped()
        {
            if(Click!=null)
                Click(this,new EventArgs());
        }
    }
}
