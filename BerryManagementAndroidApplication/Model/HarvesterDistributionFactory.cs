using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Model.LocalDataModels;

namespace BerryManagementAndroidApplication.Model
{
    public class HarvesterDistributionFactory
    {
        public SQLiteClient<HarvesterRowDistributionInOutLocal> DataClient { get; set; }
    }
}