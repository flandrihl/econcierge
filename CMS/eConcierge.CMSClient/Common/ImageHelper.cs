using System.IO;
using System.Windows.Media.Imaging;

namespace eConcierge.CMSClient.Common
{
    public class ImageHelper
    {
        public static byte[] GetImage(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }
        public static BitmapImage GetImage(byte[] imageData)
        {
            BitmapImage bitImg = new BitmapImage();
            bitImg.BeginInit();
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                bitImg.StreamSource = ms;
                bitImg.EndInit();
            }
            return bitImg;
        }
    }
}
