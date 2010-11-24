using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using eConcierge.CMSClient.CmsWindow;
using eConcierge.Common;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for LatitudeLongitude.xaml
    /// </summary>
    public partial class LatitudeLongitude : UserControl
    {
        public LatitudeLongitude()
        {
            InitializeComponent();
        }
        public double? Latitude
        {
            get
            {
                double? d = null;
                return !string.IsNullOrWhiteSpace(txtLatitude.Text) ? Convert.ToDouble(txtLatitude.Text) : d;
            }
        }
        public double? Longitude
        {
            get
            {
                double? d = null;
                return !string.IsNullOrWhiteSpace(txtLongitude.Text) ? Convert.ToDouble(txtLongitude.Text) : d;
            }
        }
        private bool IsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            Double result;
            return Double.TryParse(value, out result);

        }
        public bool IsValid()
        {
            if (!IsNumeric(txtLatitude.Text))
            {
                MessageBox.Show("Latitude can only be numeric value.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
                txtLatitude.Focus();
                return false;
            }

            if (!IsNumeric(txtLongitude.Text))
            {
                MessageBox.Show("Longitude can only be numeric value.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
                txtLatitude.Focus();
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wndGmap map = new wndGmap();
            if(map.ShowDialog().Value)
            {
                txtLatitude.Text = map.Latitude.ToString();
                txtLongitude.Text = map.Longitude.ToString();
            }
        }
    }
}
