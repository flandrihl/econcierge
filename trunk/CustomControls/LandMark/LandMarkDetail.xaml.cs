using System;
using System.Windows;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using eConcierge.Model;
using Infrasturcture;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;
using TouchAction = Infrasturcture.TouchLibrary.TouchAction;

namespace CustomControls.LandMark
{
    /// <summary>
    /// Interaction logic for DiningDetail.xaml
    /// </summary>
    public partial class LandMarkDetail : LocationControl, IMTouchControl
    {
        private readonly DTOPointOfInterest _landMark;
        public IMTContainer Container { get; set; }
        public IFrameworkManger FrameworkManager { get; set; }
        public BitmapImage Picture  { get; set; }
        public event EventHandler Closed;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        
        public LandMarkDetail(DTOPointOfInterest landMark)
        {
            _landMark = landMark;
            InitializeComponent();
            Picture = WpfUtil.BytesToImageSource(landMark.Photo);
            Title = landMark.Title;
            Description = landMark.Description;
            Address = landMark.Address;
            Telephone = landMark.Phone;
            closeButton.Click += CloseButtonClick;
            mapDirectionsButton.Click += MapDirectionsButtonClick;     
            DataContext = this;
        }

        private void MapDirectionsButtonClick(object sender, RoutedEventArgs e)
        {
            InvokeShowDirections(new DataEventArgs(_landMark));
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
            FrameworkManager.UnRegisterElement(mapDirectionsButton);
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.RemoveControl(this);
            if(Closed!=null)
                Closed(this,new EventArgs());
        }
    }
}
