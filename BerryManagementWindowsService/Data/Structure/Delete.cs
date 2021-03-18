using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure
{
    class Delete
    {
        public static void DeleteBrigade(long brigadeId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Brigades.RemoveRange(context.Brigades.Where(rp => rp.Brigade_Id == brigadeId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteBrigade()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteBrigade()\n" + ex.Message;
                }
            }
        }

        public static void DeleteCarDriver(long CarDriverId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.CarDrivers.RemoveRange(context.CarDrivers.Where(rp => rp.CarDriver_Id == CarDriverId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteCarDriver()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteCarDriver()\n" + ex.Message;
                }
            }
        }


        public static void DeleteCar(long CarId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Cars.RemoveRange(context.Cars.Where(rp => rp.Car_Id == CarId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteCar()\n" + ex.Message;
                }
            }
        }


        public static void DeleteCompanyCar(long CompanyCarId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.CompanyCars.RemoveRange(context.CompanyCars.Where(rp => rp.CompanyCar_Id == CompanyCarId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteCompanyCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteCompanyCar()\n" + ex.Message;
                }
            }
        }


        public static void DeleteCompany(long CompanyId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Companyes.RemoveRange(context.Companyes.Where(rp => rp.Company_Id == CompanyId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteCompany()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteCompany()\n" + ex.Message;
                }
            }
        }


        public static void DeleteCompanyRows(long CompanyRowsId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.CompanyRows.RemoveRange(context.CompanyRows.Where(rp => rp.CompanyRow_Id == CompanyRowsId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteCompanyRows()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteCompanyRows()\n" + ex.Message;
                }
            }
        }


        public static void DeletePoint(Point pointObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Point PointT = context.Points.Where(e => e.Point_Id == pointObj.Point_Id).FirstOrDefault();

                    if (PointT != null)
                    {
                        PointT.Point_IsActive = false;
                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა DeletePoint() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeletePoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeletePoint()\n" + ex.Message;
                }
            }
        }


      

        public static void DeleteRowBreeds(long RowBreedId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.RowBreeds.RemoveRange(context.RowBreeds.Where(rp => rp.RowBreed_Id == RowBreedId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteRowBreeds()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteRowBreeds()\n" + ex.Message;
                }
            }
        }


        public static void DeleteRow(long RowId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Rows.RemoveRange(context.Rows.Where(rp => rp.Row_Id== RowId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeleteRow()\n" + ex.Message;
                }
            }
        }

        public static void DeletePost(long PostId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Posts.RemoveRange(context.Posts.Where(rp => rp.Post_Id == PostId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeletePost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeletePost()\n" + ex.Message;
                }
            }
        }


    }
}
