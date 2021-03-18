using SQLite;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    [Table("ErrorTableReference")]
    public class ErrorTableReference
    {
        [Column("ClassName")]
        public string ClassName { get; set; }

        public ErrorTableReference(string className)
        {
            this.ClassName=className;
        }

        public ErrorTableReference()
        {
                
        }
    }
}