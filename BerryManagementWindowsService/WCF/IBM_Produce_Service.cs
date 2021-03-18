using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Produce_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Produce_Service
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<Data.Produce.XClasses.ProductModel> GetProductModel(ref string errorMessage);

        [OperationContract]
        List<Data.BreedProperty> GetBreedProperty(long? BreedPropertyId, long? BreedId, DateTime? StartTime, DateTime? EndTime, decimal? SugarStart, decimal? SugarEnd, decimal? Density, ref String errorMessage);

        [OperationContract]
        void InsertBreedProperties(Data.BreedProperty breedProperty, ref String errorMessage);

    }
}
