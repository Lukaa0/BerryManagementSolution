using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security.DataClasses
{
    public class PostRoleName
    {
        public long PostRole_Id { set; get; }
        public long PostRole_Role_Id { set; get; }
        public long PostRole_Post_Id { set; get; }
        public string PostRole_Role_Name { set; get; }
        public string PostRole_Post_Name { set; get; }
        public DateTime PostRole_Start { set; get; }
        public DateTime? PostRole_End { set; get; }

    }
}
