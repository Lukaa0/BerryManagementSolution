using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses
{
    public class PersonEverything
    {
        public long Person_Id { get; set; }
        public int Person_SideType_Id { get; set; }
        public Nullable<long> Person_Code { get; set; }
        public string Person_FirstName { get; set; }
        public string Person_LastName { get; set; }
        public string Person_Identity { get; set; }
        public Nullable<long> Person_LegalStatuseType_Id { get; set; }
        public Nullable<long> Person_LegalForm_Id { get; set; }
        public bool Person_IsResident { get; set; }
        public bool Person_GenderType_Id { get; set; }
        public System.DateTime Person_BirthDate { get; set; }
        public string Person_Address1 { get; set; }
        public string Person_Address2 { get; set; }
        public string Person_Phone1 { get; set; }
        public string Person_Phone2 { get; set; }
        public Nullable<long> Person_Bank_Id { get; set; }
        public string Person_BankAccount { get; set; }
        public string Person_BankClientName { get; set; }
        public string Person_MailAddress { get; set; }
        public Nullable<long> Person_MaritalStatus_Id { get; set; }
        public string Person_DrivingLicense { get; set; }
        public Nullable<long> Person_Nationality_Id { get; set; }
        public Nullable<long> Person_Citizenship_Id { get; set; }
        public string Person_Description { get; set; }


        public long PersonPost_Id { get; set; }
        public string PersonPost_EmployeeBarCode { get; set; }
        public long PersonPost_BalanceSheetType_Id { get; set; }
        public long PersonPost_EmployeeType_Id { get; set; }
        public long PersonPost_Person_Id { get; set; }
        public long PersonPost_Post_Id { get; set; }
        public string PersonPost_Post_BarCodePrefix { get; set; }
        public Nullable<long> PersonPost_Brigade_Id { get; set; }
        public System.DateTime PersonPost_StartDate { get; set; }
        public Nullable<System.DateTime> PersonPost_EndDate { get; set; }
        public string PersonPost_DismissalOrder { get; set; }
        public string PersonPost_Description { get; set; }

        public long Post_Id { get; set; }
        public string Post_Name { get; set; }
        public string Post_Description { get; set; }
        public string Post_BarCodePrefix { get; set; }
        public long Post_BalanceSheetType_Id { get; set; }

        public long Brigade_Id { get; set; }
        public string Brigade_Name { get; set; }
        public string Brigade_Description { get; set; }



    }
}
