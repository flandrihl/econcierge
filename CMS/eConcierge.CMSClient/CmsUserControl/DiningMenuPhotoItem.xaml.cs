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

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for DiningMenuPhotoItem.xaml
    /// </summary>
    public partial class DiningMenuPhotoItem : UserControl
    {
        public event EventHandler RemovedMenuItem;
        public DiningMenuPhotoItem()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(RemovedMenuItem != null)
            {
                RemovedMenuItem(this, null);
            }
        }
        public string PhotoPath
        {
            set { txtPhotoPath.Text = value; txtPhotoPath.ToolTip = value; }
            get { return txtPhotoPath.Text; }
        }

    }
}
