using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Infrasturcture;
using Infrasturcture.DTO;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Cafe
{
    /// <summary>
    /// Interaction logic for TouchOptionItem.xaml
    /// </summary>
    public partial class CafeItem : UserControl, IMTouchControl
    {
        public DTOCafe Cafe { get; set; }
        public IMTContainer Container { get; set; }
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public event EventHandler Click;
        public CafeItem(DTOCafe cafe)
        {
            Cafe = cafe;
            InitializeComponent();
            DataContext = this;
            Picture = WpfUtil.BytesToImageSource(Cafe.Picture);
            Title = Cafe.Title;
        }

        public void Tapped()
        {
            if(Click!=null)
                Click(this,new EventArgs());
        }
    }
}
