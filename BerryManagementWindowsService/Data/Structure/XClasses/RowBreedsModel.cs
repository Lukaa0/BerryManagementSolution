using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public partial class RowBreedsModel
    {
        public long RowBreed_Id { get; set; }
        public long RowBreed_Row_Id { get; set; }
        public long RowBreed_Breed_Id { get; set; }
        public System.DateTime RowBreed_StartDate { get; set; }
        public Nullable<System.DateTime> RowBreed_EndDate { get; set; }
        public int RowBreed_TreeCount { get; set; }
        public int RowBreed_PlantYear { get; set; }

        public int RowBreed_Sector_Number { get; set; }
        public int RowBreed_Row_Number { get; set; }
        public string RowBreed_Row_Subrow_Number { get; set; }
        public string RowBreed_Row_Barkode { get; set; }

        public string RowBreed_Breed_Name { get; set; }

    }
}
