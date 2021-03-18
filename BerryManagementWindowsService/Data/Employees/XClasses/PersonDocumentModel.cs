using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses
{
    public partial class PersonDocumentModel
    {
        public long PersonDocument_Id { get; set; }
        public long PersonDocument_Employee_Id { get; set; }
        public long PersonDocument_DocumentType_Id { get; set; }
        public string PersonDocument_DocumentType_Name { get; set; }
        public string PersonDocument_Employee_FullName { get; set; }
        public string PersonDocument_Employee_FirstName { get; set; }
        public string PersonDocument_Employee_LastName { get; set; }
        public DateTime PersonDocument_StartDate { get; set; }
        public DateTime? PersonDocument_EndDate { get; set; }
        public string PersonDocument_Number { get; set; }
        public string PersonDocument_Isuer { get; set; }
        public string PersonDocument_Description { get; set; }
        public long Citizenship_Id { get; set; }
        public string Citizenship_Citizenship_Name { get; set; }
    }
}
