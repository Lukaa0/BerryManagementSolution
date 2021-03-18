using BerryManagementAndroidApplication.EmployeeService;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    public class PersonPostModelLocal
    {
        public long PersonPostId{ get; set; }
        public string Barcode { get; set; }
        public long PersonId { get; set; }
        public string FullName { get; set; }
        public bool Direction { get; set; }
        public string ContentType { get; set; }

        public PersonPostModelLocal(EmployeeService.PersonPostModel model)
        {
            PersonPostId = model.PersonPost_Id;
            Barcode = model.PersonPost_EmployeeBarCode;
            PersonId = model.PersonPost_Person_Id;
            FullName = model.PersonPost_Person_FullName;
            Direction = model.PersonPost_Direction;
        }

        public PersonPostModelLocal()
        {
            
        }
    }
}