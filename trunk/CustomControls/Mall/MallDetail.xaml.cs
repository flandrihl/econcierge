using System;
using System.Windows;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using eConcierge.Model;
using Infrasturcture;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Mall
{
    /// <summary>
    /// Interaction logic for DiningDetail.xaml
    /// </summary>
    public partial class MallDetail : LocationControl, IMTouchControl
    {
        private readonly DTOMall _mall;
        public IMTContainer Container { get; set; }
        public IFrameworkManger FrameworkManager { get; set; }
        public BitmapImage Picture  { get; set; }
        public event EventHandler Closed;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        
        public MallDetail(DTOMall mall)
        {
            _mall = mall;
            InitializeComponent();
            Picture = WpfUtil.BytesToImageSource(mall.Photo);
            Title = mall.Title;
            Description = mall.Description;
            Address = mall.Address;
            Telephone = mall.Phone;
            closeButton.Click += CloseButtonClick;
            mapDirectionsButton.Click += MapDirectionsButtonClick;
            DataContext = this;
        }

        private void MapDirectionsButtonClick(object sender, RoutedEventArgs e)
        {
            InvokeShowDirections(new DataEventArgs(_mall));
        }

        public void Load(IFrameworkManger frameworkManger, double left, double top)
        {
            FrameworkManager = frameworkManger;
            FrameworkManager.RegisterElement((IMTouchControl)closeButton, false, new[] { TouchAction.Tap });
            FrameworkManager.RegisterElement((IMTouchControl)mapDirectionsButton, false, new[] { TouchAction.Tap });
            FrameworkManager.AddControlWithAllGestures(this, left, top);
        }

        void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        public void Close()
        {
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.RemoveControl(this);
            FrameworkManager.UnRegisterElement(mapDirectionsButton);
            if(Closed!=null)
                Closed(this,new EventArgs());
        }
    }
}
