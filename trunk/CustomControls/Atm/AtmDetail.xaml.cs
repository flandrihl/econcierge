using System;
using System.Windows;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using eConcierge.Model;
using Infrasturcture;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Atm
{
    /// <summary>
    /// Interaction logic for DiningDetail.xaml
    /// </summary>
    public partial class AtmDetail : LocationControl, IMTouchControl
    {
        private readonly DTOATM _atm;
        public IMTContainer Container { get; set; }
        public IFrameworkManger FrameworkManager { get; set; }
        public BitmapImage Picture  { get; set; }
        public event EventHandler Closed;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public event EventHandler<DataEventArgs> ShowDirections;
        public void InvokeShowDirections(DataEventArgs e)
        {
            EventHandler<DataEventArgs> handler = ShowDirections;
            if (handler != null) handler(this, e);
        }

        public AtmDetail(DTOATM atm)
        {
            _atm = atm;
            InitializeComponent();
            Picture = WpfUtil.BytesToImageSource(atm.Photo);
            Title = atm.Title;
            Description = atm.Description;
            Address = atm.Address;
            Telephone = atm.Phone;
            closeButton.Click += CloseButtonClick;
            mapDirectionsButton.Click += MapDirectionsButtonClick;     
            DataContext = this;
        }
        private void MapDirectionsButtonClick(object sender, RoutedEventArgs e)
        {
            InvokeShowDirections(new DataEventArgs(_atm));
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
            FrameworkManager.UnRegisterElement(mapDirectionsButton);
            FrameworkManager.RemoveControl(this);
            if(Closed!=null)
                Closed(this,new EventArgs());
        }
    }
}
