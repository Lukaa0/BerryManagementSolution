using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Produce
{
    public static class SelectL
    {
        internal static List<Data.Product> GetProducts(Guid? id, Guid? parentId, bool parentIdIsFiltered,
               long? rowId, long? hardvesterPersonPostId, long? userPersonPostId, ref string errorMessage)
        {
            List<Data.Product> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProducts(context, id, parentId, parentIdIsFiltered, rowId, hardvesterPersonPostId, userPersonPostId, ref errorMessage);
                    result = selectText.ToList();
                }
                if (string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  GetAllProducts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  GetAllProducts()\n" + ex.Message;
                }
            }
            return result;
        }

       

        #region AndroidApp
        public static List<XClasses.ProductModel> GetProductModel( ref string errorMessage)
        {
            List<XClasses.ProductModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProductModel(context, ref errorMessage);
                    result = selectText.ToList();
                }
               
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  GetProductModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  GetProductModel()\n" + ex.Message;
                }
            }
            return result;
        }
        #endregion

        public static List<Data.BreedProperty> GetBreedProperty(
            long? BreedPropertyId,
            long? BreedId,
            DateTime? StartTime,
            DateTime? EndTime,
            decimal? SugarStart,
            decimal? SugarEnd,
            decimal? Density
            ,ref String errorMessage)
        {
            List<Data.BreedProperty> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = (from prop in context.BreedProperties
                              join name in context.Breeds on prop.BreedProperty_Breed_Id equals name.Breed_Id
                              where (BreedPropertyId == null || BreedPropertyId == 0 || prop.BreedProperty_Id == BreedPropertyId)
                                                            && (BreedId == null || BreedId == 0 || prop.BreedProperty_Breed_Id == BreedId)
                                                            && ((StartTime == null && EndTime == null) || (prop.BreedProperty_DateTime >= StartTime && prop.BreedProperty_DateTime <= EndTime))
                                                            && ((SugarStart == null && SugarEnd == null) || (prop.BreedProperty_Sugar >= SugarStart && prop.BreedProperty_Sugar <= SugarEnd)) 
                                                            && (Density == null || prop.BreedProperty_Density == Density)
                                                            
                              select new
                              {
                                  BreedProperty_Id = prop.BreedProperty_Id,
                                  BreedProperty_Density = prop.BreedProperty_Density,
                                  BreedProperty_Sugar = prop.BreedProperty_Sugar,
                                  BreedProperty_DateTime = prop.BreedProperty_DateTime,
                                  BreedProperty_Breed_Name = name.Breed_Name,
                                  BreedProperty_Breed_Id = prop.BreedProperty_Breed_Id
                              }).ToList()
                .Select(eN => new BreedProperty()
                {
                    BreedProperty_Id = eN.BreedProperty_Id,
                    BreedProperty_Density = eN.BreedProperty_Density,
                    BreedProperty_Sugar = eN.BreedProperty_Sugar,
                    BreedProperty_DateTime = eN.BreedProperty_DateTime,
                    BreedProperty_Breed_Name = eN.BreedProperty_Breed_Name,
                    BreedProperty_Breed_Id = eN.BreedProperty_Breed_Id

                }).ToList<BreedProperty>();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetBreedProperty()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n GetBreedProperty()\n" + ex.Message;
                }
            }
            return result;
        }


    }
}
