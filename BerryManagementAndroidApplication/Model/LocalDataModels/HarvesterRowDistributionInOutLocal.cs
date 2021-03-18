using System;
using BerryManagementAndroidApplication.OperationService;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    public class HarvesterRowDistributionInOutLocal
    {
        //public HarvesterRowDistributionInOutLocal(HarvesterRowDistributionInOut harv)
        //{
        //    HarvesterRowDistributionInOut_DateTimeField = harv.HarvesterRowDistributionInOut_DateTime;
        //    HarvesterRowDistributionInOut_DirectionField = harv.HarvesterRowDistributionInOut_Direction;
        //    HarvesterRowDistributionInOut_HarvesterBarCodeField = harv.HarvesterRowDistributionInOut_HarvesterBarCode;
        //    HarvesterRowDistributionInOut_Harvester_PersonPost_IdField = harv.HarvesterRowDistributionInOut_Harvester_PersonPost_Id;
        //    HarvesterRowDistributionInOut_IdField = harv.HarvesterRowDistributionInOut_Id;
        //    HarvesterRowDistributionInOut_IsCompliteField = harv.HarvesterRowDistributionInOut_IsComplite;
        //    HarvesterRowDistributionInOut_Row_BarCodeField = harv.HarvesterRowDistributionInOut_Row_BarCode;
        //    HarvesterRowDistributionInOut_User_PersonPost_IdField = harv.HarvesterRowDistributionInOut_User_PersonPost_Id;
        //}

        public HarvesterRowDistributionInOutLocal()
        {
                
        }

        public DateTime HarvesterRowDistributionInOut_DateTimeField { get; set; }
        public bool HarvesterRowDistributionInOut_DirectionField { get; set; }
        public bool HarvesterRowDistributionInOut_DirectionFieldSpecified { get; set; }
        public string HarvesterRowDistributionInOut_HarvesterBarCodeField { get; set; }

        public long HarvesterRowDistributionInOut_Harvester_PersonPost_IdField { get; set; }
        public bool HarvesterRowDistributionInOut_Harvester_PersonPost_IdFieldSpecified { get; set; }
        public string HarvesterRowDistributionInOut_IdField { get; set; }
        public bool HarvesterRowDistributionInOut_IsCompliteField { get; set; }
        public bool HarvesterRowDistributionInOut_IsCompliteFieldSpecified { get; set; }
        public string HarvesterRowDistributionInOut_Row_BarCodeField { get; set; }
        public string HarvesterRowDistributionInOut_User_PersonPost_IdField { get; set; }
    }
}