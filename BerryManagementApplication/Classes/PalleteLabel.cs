using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementApplication.Classes
{
    public class PalleteLabel
    {
        public string PalleteBarcode { set; get; }
        public string PalleteWeightNet { set; get; }
        public string PalleteWeightGross { set; get; }
        public string PalleteBoxCount { set; get; }
        public string PalleteDatetime { set; get; }
        public List<Product> PalleteProducts { set; get; }
        public Bitmap BitmapBarcode_128
        {
            get
            {
                return BarcodeToImage.BarcodeToImage_128(PalleteBarcode);
            }
        }

        public class Product
        {
            public string ProductName { set; get; }
            public string ProductWeight { set; get; }
            public string ProductBoxCount { set; get; }
        }
    }
}
