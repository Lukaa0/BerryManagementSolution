using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security.DataClasses
{
    public partial class UserModel
    {
        public long User_Person_ID { get; set; }
        public string User_Person_FirstName { get; set; }
        public string User_Person_LastName { get; set; }
        public string User_Password { get; set; }
        public bool User_PasswordIsReset { get; set; }
        public long User_PersonPost_ID { get; set; }
        public long User_Role_ID { get; set; }
        public long User_Brigade_ID { get; set; }
        public string User_Role_Name { get; set; }
    }
}