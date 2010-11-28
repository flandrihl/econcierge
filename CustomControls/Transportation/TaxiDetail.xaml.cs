using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using eConcierge.Business;
using eConcierge.Model;

namespace CustomControls.Transportation
{
    /// <summary>
    /// Interaction logic for TaxiDetail.xaml
    /// </summary>
    public partial class TaxiDetail : UserControl
    {
        private const int NoOfItemsPerColumn = 2;
        private List<DTOTransportationTaxi> _taxiDetails;
        public TaxiDetail()
        {
            InitializeComponent();
        }
        public int SetTaxi(int transportationId)
        {
            var service = new TransportationTaxiService();
            _taxiDetails = service.GetTransportationTaxis(transportationId);
            PopulateTaxiDetail();
            return _taxiDetails.Count / 8;
        }
        public void PopulateTaxiDetail(int pageIndex = 0)
        {
            if (_taxiDetails.Count > 0)
            {
            grdCategory.Children.Clear();
            grdCategory.RowDefinitions.Clear();
            grdCategory.ColumnDefinitions.Clear();

            AddColumns();
            int col = 0, row = -1;
           
                for (int index = pageIndex * 8; index < (pageIndex + 1) * 8; index++)
                {

                    var detail = _taxiDetails[index];

                    if (col == 0)
                    {
                        grdCategory.RowDefinitions.Add(new RowDefinition());
                        row++;
                    }
                    var item = new TaxiItem();
                    item.txbTitle.Text = detail.Title;
                    item.txbDescription.Text = detail.Phone;
                    grdCategory.Children.Add(item);
                    item.SetValue(Grid.ColumnProperty, col);
                    item.SetValue(Grid.RowProperty, row);
                    if (col == 0)
                        item.Margin = new Thickness(0, 10, 60, 0);
                    else
                        item.Margin = new Thickness(0, 10, 0, 0);
                    col++;
                    if (col == NoOfItemsPerColumn) col = 0;
                }
            }
        }

        private void AddColumns()
        {
            for (int col = 0; col < NoOfItemsPerColumn; col++)
            {
                grdCategory.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
