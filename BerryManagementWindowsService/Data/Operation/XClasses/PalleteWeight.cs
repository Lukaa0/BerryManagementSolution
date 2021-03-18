using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class PalleteWeight
    {
        public string Pallete_BarCode { get; set; }
        public decimal Pallete_Net_weight { get; set; }
        public decimal Pallete_Gross_weight { get; set; }
    }
}
