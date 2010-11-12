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
        public DTOAtm Atm { get; set; }
        public IMTContainer Container { get; set; }
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public event EventHandler Click;
        public AtmItem(DTOAtm atm)
        {
            Atm = atm;
            InitializeComponent();
            DataContext = this;
            Picture = WpfUtil.BytesToImageSource(Atm.Picture);
            Title = Atm.Title;
        }

        public void Tapped()
        {
            if(Click!=null)
                Click(this,new EventArgs());
        }
    }
}
