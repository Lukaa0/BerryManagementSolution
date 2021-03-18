using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Produce
{
    public static class Update
    {
        public static void UpdateProduct(Product product, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateProductWithOuterContext(context, product, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProduct()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProduct()\n" + ex.Message;
                }
            }
        }



        public static void UpdateProductWithOuterContext(BerryManagementEntities context, Product product, ref String errorMessage)
        {
            try
            {
                Product productT = SelectQ.GetProducts(context, product.Product_Id,null,false, null, null, null, ref errorMessage).FirstOrDefault();
                if (productT != null)
                {
                    productT.Product_DateTime = product.Product_DateTime;
                    productT.Product_Harvester_PersonPost_Id = product.Product_Harvester_PersonPost_Id;
                    productT.Product_ParentProduct_Id = product.Product_ParentProduct_Id;
                    productT.Product_Row_Id = product.Product_Row_Id;
                    productT.Product_User_PersonPost_Id = product.Product_User_PersonPost_Id;
                }
                else
                {
                    errorMessage = "შესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProductWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProductWithOuterContext()\n" + ex.Message;
                }
            }
        }

    }
}
