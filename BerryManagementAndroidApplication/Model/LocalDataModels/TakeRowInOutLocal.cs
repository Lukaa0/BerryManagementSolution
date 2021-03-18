using System;
using BerryManagementAndroidApplication.OperationService;
using SQLite;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    [Table("TakeRowInOutLocal")]
    public class TakeRowInOutLocal
    {
        //public TakeRowInOutLocal(TakeRowInOut obj)
        //{
        //    Id = obj.TakeRowInOut_Id;
        //    BrigadeId = obj.TakeRowInOut_Brigade_Id;
        //    Date = obj.TakeRowInOut_DateTime;
        //    Direction = obj.TakeRowInOut_Direction;
        //    IsComplete = obj.TakeRowInOut_IsComplite;
        //    RowBarCode = obj.TakeRowInOut_Row_BarCode;
        //    PersonPostId = obj.TakeRowInOut_User_PersonPost_Id;
        //}

        public TakeRowInOutLocal()
        {
                
        }

        [PrimaryKey]
        public string Id { get; set; }

        public long? BrigadeId { get; set; }

        public DateTime Date { get; set; }


        public bool Direction { get; set; }


        public bool IsComplete { get; set; }

        public string RowBarCode { get; set; }

        public long PersonPostId { get; set; }

    }
}