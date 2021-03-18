using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class TakeRowModel
    {
        public Nullable<long> TakeRow_Id { get; set; }
        public Nullable<long> TakeRow_Row_Id { get; set; }
        public Nullable<long> TakeRow_Brigade_Id { get; set; }
        public System.Guid TakeRow_In_TakeRowInOut_Id { get; set; }
        public Nullable<long> TakeRow_In_TUser_PersonPost_Id { get; set; }
        public System.DateTime TakeRow_In_DateTime { get; set; }
        public Nullable<System.Guid> TakeRow_Out_TakeRowInOut_Id { get; set; }
        public Nullable<long> TakeRow_Out_User_PersonPost_Id { get; set; }
        public Nullable<System.DateTime> TakeRow_Out_DateTime { get; set; }
        public string Row_Barcode { get; set; }
        public string Brigade_Name { get; set; }
    }
}
