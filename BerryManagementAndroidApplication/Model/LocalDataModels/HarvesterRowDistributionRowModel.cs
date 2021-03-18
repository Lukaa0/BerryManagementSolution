using BerryManagementAndroidApplication.StructureService;
using SQLite;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    public class HarvesterRowDistributionRowModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id{ get; set; }
        public long RowId{ get; set; }
        public long SectorNumber { get; set; }


        public long RowNumber { get; set; }
        public string RowSubRowNumber { get; set; }
        public string Barcode { get; set; }
        public bool Direction { get; set; }

        public HarvesterRowDistributionRowModel()
        {
                
        }

        public HarvesterRowDistributionRowModel(RowModel row)
        {
            RowId = row.Row_Id;
            SectorNumber = row.Sector_Number;
            RowNumber = row.Row_Number;
            RowSubRowNumber = row.Row_Subrow_Number;
            Barcode = row.Row_Barkode;
            Direction = row.direction; 
        }


    }
}