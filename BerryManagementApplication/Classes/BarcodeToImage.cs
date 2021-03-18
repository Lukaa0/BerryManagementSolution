using System.Drawing;
using ZXing;

namespace BerryManagementApplication.Classes
{
    public static class BarcodeToImage
    {
        public static Bitmap BarcodeToImage_128(string barcode)
        {
            Bitmap result = null;
            BarcodeWriter barcodeWriter = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            barcodeWriter.Options = new ZXing.Common.EncodingOptions() { Width = 10, Height = 1, Margin = 0 };
            result = barcodeWriter.Write(barcode);
            return result;
        }
    }
}
