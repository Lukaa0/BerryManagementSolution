using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerryPackagingApplication.BM_Operarion_ServiceRefernce;
using BerryPackagingApplication.BM_Library_ServiceReference;

namespace BerryPackagingApplication.DbServices
{
    public class Services
    {
        public static ProductRepackAndWeight GetProductRepackAndWeight(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            ProductRepackAndWeight result = null;
            using (BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceClient())
            {
                result = serviceClient.FixProductRepackAndWeight(productRepackAndWeight, ref errorMessage);
            }
            return result;
        }

        public static dynamic InsertComboBox()
        {
            List<tf_ProductQualityes_Result> result;
            string errorMessage = null;
            using (BM_Library_ServiceClient serviceClient = new BM_Library_ServiceClient())
            {
                result = serviceClient.GetProductQualityes(null, null, ref errorMessage).OrderByDescending(q => q.ProductQuality_Id).ToList();

            }
            return result;
        }

        public static bool CheckContainer(string barCode)
        {
            List<ContainerLocation> List;
            bool result = false;
            string errorMessage = null;
            using (BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceClient())
            {
                List = serviceClient.CheckContainerLocationForPackaging(barCode, ref errorMessage);

            }
            if(List.Count != 0)
            {
                result = true;
            }

            return result;
        }
    }
}
