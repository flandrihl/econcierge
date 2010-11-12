using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Infrasturcture;
using Infrasturcture.DTO;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Mall
{
    /// <summary>
    /// Interaction logic for TouchOptionItem.xaml
    /// </summary>
    public partial class MallItem : UserControl, IMTouchControl
    {
        public DTOMall Mall { get; set; }
        public IMTContainer Container { get; set; }
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public event EventHandler Click;
        public MallItem(DTOMall mall)
        {
            Mall = mall;
            InitializeComponent();
            DataContext = this;
            Picture = WpfUtil.BytesToImageSource(Mall.Picture);
            Title = Mall.Title;
        }

        public void Tapped()
        {
            if(Click!=null)
                Click(this,new EventArgs());
        }
    }
}
