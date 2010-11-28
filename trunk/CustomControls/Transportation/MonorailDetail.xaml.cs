using System.Collections.Generic;
using System.Windows.Controls;
using eConcierge.Business;
using eConcierge.Model;
using Infrasturcture;

namespace CustomControls.Transportation
{
    /// <summary>
    /// Interaction logic for MonorailDetail.xaml
    /// </summary>
    public partial class MonorailDetail : UserControl
    {
        private List<DTOTransportationMonorail> _monorailDetails;

        public MonorailDetail()
        {
            InitializeComponent();
        }

        public int SetMonorail(int transportationId)
        {
            var service = new TransportationMonorailService();
            _monorailDetails = service.GetTransportationMonorails(transportationId);
            PopulateMonorailDetail();
            return _monorailDetails.Count;
        }
        public void PopulateMonorailDetail(int pageIndex = 0)
        {
            if (_monorailDetails.Count > 0)
            {
                var detail = _monorailDetails[pageIndex];
                txbTitle.Text = detail.Title;
                txbDescription.Text = detail.Description;
                imgMonorail.Source = WpfUtil.BytesToImageSource(detail.Photo);
            }
        }
    }
}
