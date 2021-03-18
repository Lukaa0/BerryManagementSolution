using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public class RowWithDateModel
    {
        public long Row_Id { get; set; }
        public int Sector_Number { get; set; }
        public int Row_Number { get; set; }
        public string Row_Subrow_Number { get; set; }
        public string Row_Barkode { get; set; }
        public System.DateTime RowBreed_StartDate { get; set; }
        public Nullable<System.DateTime> RowBreed_EndDate { get; set; }

    }
}
