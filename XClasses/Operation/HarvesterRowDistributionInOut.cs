using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XClassess.Operation
{
    public class HarvesterRowDistributionInOut
    {
        public DateTime HarvesterRowDistributionInOut_DateTimeField { get; set; }
        public bool HarvesterRowDistributionInOut_DirectionField { get; set; }
        public bool HarvesterRowDistributionInOut_DirectionFieldSpecified { get; set; }
        public string HarvesterRowDistributionInOut_HarvesterBarCodeField { get; set; }
        public long HarvesterRowDistributionInOut_Harvester_PersonPost_IdField { get; set; }
        public bool HarvesterRowDistributionInOut_Harvester_PersonPost_IdFieldSpecified { get; set; }
        public Guid HarvesterRowDistributionInOut_IdField { get; set; }
        public bool HarvesterRowDistributionInOut_IsCompliteField { get; set; }
        public bool HarvesterRowDistributionInOut_IsCompliteFieldSpecified { get; set; }
        public string HarvesterRowDistributionInOut_Row_BarCodeField { get; set; }
        public string HarvesterRowDistributionInOut_User_PersonPost_IdField { get; set; }
    }
}
