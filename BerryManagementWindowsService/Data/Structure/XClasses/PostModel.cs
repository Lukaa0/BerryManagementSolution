using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public partial class PostModel
    {
        public long Post_Id { get; set; }
        public string Post_Name { get; set; }
        public string Post_Description { get; set; }
        public string Post_BarCodePrefix { get; set; }
        public long Post_BalanceSheetType_Id { get; set; }

        public string BalanceSheetType_Name { get; set; }
    }
}
