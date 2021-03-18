using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public class CompanyeModel
    {
        public long Company_Id { get; set; }
        public string Company_Name { get; set; }
        public string Company_Identity { get; set; }
        public int Company_SideType_Id { get; set; }
        public string Company_SideType_Name { get; set; }
        public long Company_CitizenshipId { get; set; }
        public string Company_Citizenship_Name { get; set; }
        public string Company_Citizenship_NameEn { get; set; }
        public string Company_Address1 { get; set; }
        public string Company_Address2 { get; set; }
        public string Company_Phone1 { get; set; }
        public string Company_Phone2 { get; set; }
        public string Company_IBAN { get; set; }

        public string Company_RS_UserId { get; set; }
        public string Company_RS_Password { get; set; }
    }
}
