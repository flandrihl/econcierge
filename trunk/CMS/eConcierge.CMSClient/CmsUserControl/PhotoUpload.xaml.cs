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
using Microsoft.Win32;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for PhotoUpload.xaml
    /// </summary>
    public partial class PhotoUpload : UserControl
    {
        public PhotoUpload()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg|jpeg|png";
            if(dialog.ShowDialog().Value)
            {
                txtPhotoPath.Text = dialog.FileName;
            }

        }
        public string FilePath
        {
            get
            {
                return txtPhotoPath.Text;
            }
        }
        public Visibility IsSeeVisible
        {
            set
            {
                btnSee.Visibility = value;
            }
        }

        private void btnSee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
