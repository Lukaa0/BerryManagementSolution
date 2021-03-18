using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security.DataClasses
{
    public class UserPermissions
    {
        public long UserId { set; get; }
        public List<long> UserPermisions { set; get; }

        public UserPermissions()
        { }
    }
}
