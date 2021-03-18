using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Produce
{
    public static class SelectQ
    {

        #region AndroidApp
        public static IQueryable<XClasses.ProductModel> GetProductModel(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<XClasses.ProductModel> result = null;
            try
            {
                result = from product in context.Products
                         join row in context.Rows on product.Product_Row_Id equals row.Row_Id
                         join harvesterPersonPost in context.PersonPosts on product.Product_Harvester_PersonPost_Id equals harvesterPersonPost.PersonPost_Id
                         join harvester in context.Persons on harvesterPersonPost.PersonPost_Person_Id equals harvester.Person_Id
                         join userPersonPost in context.PersonPosts on product.Product_User_PersonPost_Id equals userPersonPost.PersonPost_Id
                         join users in context.Persons on userPersonPost.PersonPost_Person_Id equals users.Person_Id
                         join breed in context.Breeds on product.Product_Breed_Id equals breed.Breed_Id
                         select new XClasses.ProductModel
                         {
                             Product_Id = product.Product_Id,
                             Product_ParentProduct_Id = product.Product_ParentProduct_Id,
                             Product_Row_Id = product.Product_Row_Id,
                             Product_Row_Barkode = row.Row_Barkode,
                             Product_Harvester_PersonPost_Id = product.Product_Harvester_PersonPost_Id,
                             Product_Harvester_FullName = harvester.Person_FirstName + " " + harvester.Person_LastName,
                             Product_Harvester_Barkode = harvesterPersonPost.PersonPost_EmployeeBarCode,
                             Product_User_PersonPost_Id = product.Product_User_PersonPost_Id,
                             Product_User_Barkode = userPersonPost.PersonPost_EmployeeBarCode,
                             Product_User_FullName = users.Person_FirstName + " " + users.Person_LastName,
                             Product_DateTime = product.Product_DateTime,
                             Product_Breed_Id = product.Product_Breed_Id,
                             Product_Breed_Name = breed.Breed_Name,
                             Product_Error = null,
                             Product_IsComplete = true
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetProductModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetProductModel()\n" + ex.Message;
                }
            }
            return result;
        }
        #endregion

        internal static IQueryable<Data.Product> GetProducts(BerryManagementEntities context, Guid? id, Guid? parentId, 
            bool parentIdIsFiltered, long? rowId, long? hardvesterPersonPostId, long? userPersonPostId, ref string errorMessage)
        {
            IQueryable<Data.Product> result = null;
            try
            {
                result = context.Products;
                if (id != null)
                {
                    result = result.Where(p => p.Product_Id == id);
                }
                if (parentIdIsFiltered)
                {
                    result = result.Where(p => p.Product_ParentProduct_Id == parentId);
                }
                if (rowId != null)
                {
                    result = result.Where(p => p.Product_Row_Id == rowId);
                }
                if (hardvesterPersonPostId != null)
                {
                    result = result.Where(p => p.Product_Harvester_PersonPost_Id == hardvesterPersonPostId);
                }
                if (userPersonPostId != null)
                {
                    result = result.Where(p => p.Product_User_PersonPost_Id == userPersonPostId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetAllProducts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetAllProducts()\n" + ex.Message;
                }
            }
            return result;
        }

       

    }
}
