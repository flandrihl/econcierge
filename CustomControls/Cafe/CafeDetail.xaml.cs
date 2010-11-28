using System;
using System.Windows;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using eConcierge.Model;
using Infrasturcture;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Cafe
{
    /// <summary>
    /// Interaction logic for DiningDetail.xaml
    /// </summary>
    public partial class CafeDetail : LocationControl, IMTouchControl
    {
        private readonly DTOCafe _cafe;
        public IMTContainer Container { get; set; }
        public IFrameworkManger FrameworkManager { get; set; }
        public BitmapImage Picture  { get; set; }
        public event EventHandler Closed;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        
        public CafeDetail(DTOCafe cafe)
        {
            _cafe = cafe;
            InitializeComponent();
            Picture = WpfUtil.BytesToImageSource(cafe.Photo);
            Title = cafe.Title;
            Description = cafe.Description;
            Address = cafe.Address;
            Telephone = cafe.Phone;
            Latitude = cafe.Latitude;
            Longitude = cafe.Longitude;
            closeButton.Click += CloseButtonClick;
            mapDirectionsButton.Click += MapDirectionsButtonClick;   
            DataContext = this;
        }

        private void MapDirectionsButtonClick(object sender, RoutedEventArgs e)
        {
            InvokeShowDirections(new DataEventArgs(_cafe));
        }

        protected double? Longitude { get; set; }

        protected double? Latitude { get; set; }

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
            FrameworkManager.UnRegisterElement(mapDirectionsButton);
            FrameworkManager.RemoveControl(this);
            if(Closed!=null)
                Closed(this,new EventArgs());
        }
    }
}
