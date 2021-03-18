using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Produce_Service" in both code and config file together.
    public class BM_Produce_Service : IBM_Produce_Service
    {
        public void DoWork()
        {
        }

        public List<Data.Produce.XClasses.ProductModel> GetProductModel(ref string errorMessage)
        {
            return Data.Produce.SelectL.GetProductModel(ref errorMessage);
        }


        public List<Data.BreedProperty> GetBreedProperty(long? BreedPropertyId,long? BreedId,DateTime? StartTime,DateTime? EndTime, decimal? SugarStart, decimal? SugarEnd, decimal? Density, ref String errorMessage)
        {
            return Data.Produce.SelectL.GetBreedProperty(BreedPropertyId,BreedId,StartTime,EndTime,SugarStart,SugarEnd,Density,ref errorMessage);
        }


        public void InsertBreedProperties(Data.BreedProperty breedProperty, ref String errorMessage)
        {
            Data.Produce.Insert.InsertBreedProperties(breedProperty, ref errorMessage);
        }

    }

}
