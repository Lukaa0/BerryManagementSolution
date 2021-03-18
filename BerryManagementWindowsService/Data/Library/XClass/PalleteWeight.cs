using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library.XClass
{
    public class PalleteWeight
    {
        public string Pallete_BarCode { get; set; }
        public decimal Pallete_Net_weight { get; set; }
        public decimal Pallete_Gross_weight { get; set; }
    }
}
