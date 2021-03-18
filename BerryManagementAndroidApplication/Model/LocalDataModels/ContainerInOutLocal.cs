using System;
using BerryManagementAndroidApplication.OperationService;
using SQLite;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    [Table("ContainerInOutLocal")]
    public class ContainerInOutLocal
    {
        //public ContainerInOutLocal(ContainerMoveInOut container)
        //{
        //    Id = container.ContainerMoveInOut_Id;
        //    Direction = container.ContainerMoveInOut_Direction;
        //    ContainerBarCode = container.ContainerMoveInOut_Container_BarCode;
        //    TransportBarCode = container.ContainerMoveInOut_PointCar_BarCode;
        //    Date = container.ContainerMoveInOut_DateTime;
        //    PersonPostId = container.ContainerMoveInOut_User_PersonPost_Id;
        //    Point_Id = container.ContainerMoveInOut_User_Point_Id;
        //    IsComplete = container.ContainerMoveInOut_IsComplite;
        //}

        public ContainerInOutLocal()
        {
            
        }
        [PrimaryKey]
        public string Id { get; set; }
        public bool Direction { get; set; }
        public string ContainerBarCode { get; set; }
        public string TransportBarCode { get; set; }
        public System.DateTime Date{ get; set; }
        public long PersonPostId { get; set; }
        public long Point_Id { get; set; }
        public bool IsComplete{ get; set; }

        
    }
}