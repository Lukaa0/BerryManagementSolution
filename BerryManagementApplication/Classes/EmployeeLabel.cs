using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BerryManagementApplication.Classes
{
    public class EmployeeLabel
    {
        public BM_Employee_ServiceReference.EmployeeLabel Employee { set; get; }
        public Bitmap BitmapBarcode_128
        {
            get
            {
                return BarcodeToImage.BarcodeToImage_128(Employee.Barcode);
            }
        }
    }
}
