using System;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using Infrasturcture;
using Infrasturcture.DTO;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Atm
{
    /// <summary>
    /// Interaction logic for DiningDetail.xaml
    /// </summary>
    public partial class AtmDetail : AnimatableControl, IMTouchControl
    {
        public IMTContainer Container { get; set; }
        public IFrameworkManger FrameworkManager { get; set; }
        public BitmapImage Picture  { get; set; }
        public event EventHandler Closed;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        
        public AtmDetail(DTOLandMark landMark)
        {
            InitializeComponent();
            Picture = WpfUtil.BytesToImageSource(landMark.Picture);
            Title = landMark.Title;
            Description = landMark.Description;
            Address = landMark.Address;
            Telephone = landMark.Telephone;
            closeButton.Click += CloseButtonClick;
            DataContext = this;
        }

        public void Load(IFrameworkManger frameworkManger, double left, double top)
        {
            FrameworkManager = frameworkManger;
            FrameworkManager.RegisterElement((IMTouchControl)closeButton, false, new[] { TouchAction.Tap });
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
            if(Closed!=null)
                Closed(this,new EventArgs());
        }
    }
}
