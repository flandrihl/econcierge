using System;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using Infrasturcture;
using Infrasturcture.DTO;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Mall
{
    /// <summary>
    /// Interaction logic for DiningDetail.xaml
    /// </summary>
    public partial class MallDetail : AnimatableControl, IMTouchControl
    {
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
            InitializeComponent();
            Picture = WpfUtil.BytesToImageSource(mall.Picture);
            Title = mall.Title;
            Description = mall.Description;
            Address = mall.Address;
            Telephone = mall.Telephone;
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
