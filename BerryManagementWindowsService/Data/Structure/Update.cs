using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure
{
    public partial class Update
    {
        public static void UpdateBrigade(Brigade brigadeObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Brigade CheckExist = context.Brigades.Where(e => e.Brigade_Id == brigadeObj.Brigade_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.Brigade_Id = brigadeObj.Brigade_Id;
                        CheckExist.Brigade_Name = brigadeObj.Brigade_Name;
                        CheckExist.Brigade_Description = brigadeObj.Brigade_Description;
                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateBrigade() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateBrigade()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateBrigade()\n" + ex.Message;
                }
            }
        }

        public static void UpdateCarDriver(CarDriver CarDriverObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    CarDriver CheckExist = context.CarDrivers.Where(e => e.CarDriver_Id == CarDriverObj.CarDriver_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.CarDriver_Id = CarDriverObj.CarDriver_Id;
                        CheckExist.CarDriver_PersonPost_Id = CarDriverObj.CarDriver_PersonPost_Id;
                        CheckExist.CarDriver_Person_Id = CarDriverObj.CarDriver_Person_Id;
                        CheckExist.CarDriver_StartDate = CarDriverObj.CarDriver_StartDate;
                        CheckExist.CarDriver_EndDate = CarDriverObj.CarDriver_EndDate;
                        CheckExist.CarDriver_Car_Id = CarDriverObj.CarDriver_Car_Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateCarDriver ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateCarDriver\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateCarDriver\n" + ex.Message;
                }
            }
        }



        public static void UpdateCar(Car CarObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Car CheckExist = context.Cars.Where(e => e.Car_Id == CarObj.Car_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.Car_Id = CarObj.Car_Id;
                        CheckExist.Car_Model = CarObj.Car_Model;
                        CheckExist.Car_Number = CarObj.Car_Number;
                        CheckExist.Car_SideType_Id = CarObj.Car_SideType_Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateCar() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის განახლება ვერ განახლდა: UpdateCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateCar()\n" + ex.Message;
                }
            }
        }


        public static void UpdateCompanyCar(CompanyCar companyCarObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    CompanyCar CheckExist = context.CompanyCars.Where(e => e.CompanyCar_Id == companyCarObj.CompanyCar_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.CompanyCar_Id = companyCarObj.CompanyCar_Id;
                        CheckExist.CompanyCar_Car_Id = companyCarObj.CompanyCar_Car_Id;
                        CheckExist.CompanyCar_Company_Id = companyCarObj.CompanyCar_Company_Id;
                        CheckExist.CompanyCar_EndDate = companyCarObj.CompanyCar_EndDate;
                        CheckExist.CompanyCar_StartDate = companyCarObj.CompanyCar_StartDate;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateCompanyCar() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateCompanyCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateCompanyCar()\n" + ex.Message;
                }
            }
        }


        public static void UpdateCompany(Companye companyObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Companye CheckExist = context.Companyes.Where(e => e.Company_Id == companyObj.Company_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.Company_Id = companyObj.Company_Id;
                        CheckExist.Company_Identity = companyObj.Company_Identity;
                        CheckExist.Company_Name = companyObj.Company_Name;
                        CheckExist.Company_Phone1 = companyObj.Company_Phone1;
                        CheckExist.Company_Phone2 = companyObj.Company_Phone2;
                        CheckExist.Company_SideType_Id = companyObj.Company_SideType_Id;
                        CheckExist.Company_Address1 = companyObj.Company_Address1;
                        CheckExist.Company_Address2 = companyObj.Company_Address2;
                        CheckExist.Company_CitizenshipId = companyObj.Company_CitizenshipId;
                        CheckExist.Company_IBAN = companyObj.Company_IBAN;
                        CheckExist.Company_RS_UserId = companyObj.Company_RS_UserId;
                        CheckExist.Company_RS_Password = companyObj.Company_RS_Password;
                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateCompany() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateCompany()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateCompany()\n" + ex.Message;
                }
            }
        }


        public static void UpdateCompanyRow(CompanyRow companyRowObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    CompanyRow CheckExist = context.CompanyRows.Where(e => e.CompanyRow_Id == companyRowObj.CompanyRow_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.CompanyRow_Id = companyRowObj.CompanyRow_Id;
                        CheckExist.CompanyRow_Row_Id = companyRowObj.CompanyRow_Row_Id;
                        CheckExist.CompanyRow_StartDate = companyRowObj.CompanyRow_StartDate;
                        CheckExist.CompanyRow_EndDate = companyRowObj.CompanyRow_EndDate;
                        CheckExist.CompanyRow_Company_Id = companyRowObj.CompanyRow_Company_Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateCompanyRow() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateCompanyRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateCompanyRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdatePoint(Point pointObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Point CheckExist = context.Points.Where(e => e.Point_Id == pointObj.Point_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.Point_Id = pointObj.Point_Id;
                        CheckExist.Point_Address = pointObj.Point_Address;
                        CheckExist.Point_BarCode = pointObj.Point_BarCode;
                        CheckExist.Point_Car_Id = pointObj.Point_Car_Id;
                        CheckExist.Point_Description = pointObj.Point_Description;
                        CheckExist.Point_IsActive = pointObj.Point_IsActive;
                        CheckExist.Point_Name = pointObj.Point_Name;
                        CheckExist.Point_PointType_Id = pointObj.Point_PointType_Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdatePoint() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdatePoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdatePoint()\n" + ex.Message;
                }
            }
        }


        public static void UpdatePost(Post postObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Post CheckExist = context.Posts.Where(e => e.Post_Id == postObj.Post_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.Post_Id = postObj.Post_Id;
                        CheckExist.Post_Name = postObj.Post_Name;
                        CheckExist.Post_Description = postObj.Post_Description;
                        CheckExist.Post_BarCodePrefix = postObj.Post_BarCodePrefix;
                        CheckExist.Post_BalanceSheetType_Id = postObj.Post_BalanceSheetType_Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdatePost() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdatePost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdatePost()\n" + ex.Message;
                }
            }
        }


        public static void UpdateRowBreed(RowBreed rowBreedObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    RowBreed CheckExist = context.RowBreeds.Where(e => e.RowBreed_Id == rowBreedObj.RowBreed_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.RowBreed_Id = rowBreedObj.RowBreed_Id;
                        CheckExist.RowBreed_Row_Id = rowBreedObj.RowBreed_Row_Id;
                        CheckExist.RowBreed_StartDate = rowBreedObj.RowBreed_StartDate;
                        CheckExist.RowBreed_EndDate = rowBreedObj.RowBreed_EndDate;
                        CheckExist.RowBreed_Breed_Id = rowBreedObj.RowBreed_Breed_Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateRowBreed() ";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateRowBreed()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateRowBreed()\n" + ex.Message;
                }
            }
        }


        public static void UpdateRow(Row rowObj, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Row CheckExist = context.Rows.Where(e => e.Row_Id == rowObj.Row_Id).FirstOrDefault();


                    Row CheckExist1 = context.Rows.Where(e => e.Sector_Number == rowObj.Sector_Number)
                    .Where(e => e.Row_Number == rowObj.Row_Number)
                    .Where(e => e.Row_Subrow_Number == rowObj.Row_Subrow_Number).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.Row_Id = rowObj.Row_Id;
                        CheckExist.Sector_Number = rowObj.Sector_Number;
                        CheckExist.Row_Number = rowObj.Row_Number;
                        CheckExist.Row_Subrow_Number = rowObj.Row_Subrow_Number;

                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "ჩანაწერი ვერ მოიძებნა UpdateRow() ან მონაცემები დაემთხვა სხვა მონაცემებს";
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის განახლება ვერ მოხერხდა: UpdateRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateRow()\n" + ex.Message;
                }
            }
        }


        public static void UpdateCompanyRowForTransaction(BerryManagementEntities context, CompanyRow companyRowObj, ref string errorMessage)
        {
            try
            {

                CompanyRow CheckExist = context.CompanyRows.Where(e => e.CompanyRow_Id == companyRowObj.CompanyRow_Id).FirstOrDefault();

                if (CheckExist != null)
                {
                    CheckExist.CompanyRow_Id = companyRowObj.CompanyRow_Id;
                    CheckExist.CompanyRow_Row_Id = companyRowObj.CompanyRow_Row_Id;
                    CheckExist.CompanyRow_StartDate = companyRowObj.CompanyRow_StartDate;
                    CheckExist.CompanyRow_EndDate = companyRowObj.CompanyRow_EndDate;
                    CheckExist.CompanyRow_Company_Id = companyRowObj.CompanyRow_Company_Id;


                }
                else
                {
                    errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateCompanyRowForTransaction() ";
                }
            }

            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateCompanyRowForTransaction()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateCompanyRowForTransaction()\n" + ex.Message;
                }
            }
        }

        public static void UpdateRowBreedForTransaction(BerryManagementEntities context, RowBreed rowBreedObj, ref string errorMessage)
        {
            try
            {

                RowBreed CheckExist = context.RowBreeds.Where(e => e.RowBreed_Id == rowBreedObj.RowBreed_Id).FirstOrDefault();

                if (CheckExist != null)
                {
                    CheckExist.RowBreed_Id = rowBreedObj.RowBreed_Id;
                    CheckExist.RowBreed_Row_Id = rowBreedObj.RowBreed_Row_Id;
                    CheckExist.RowBreed_StartDate = rowBreedObj.RowBreed_StartDate;
                    CheckExist.RowBreed_EndDate = rowBreedObj.RowBreed_EndDate;
                    CheckExist.RowBreed_Breed_Id = rowBreedObj.RowBreed_Breed_Id;
                    CheckExist.RowBreed_PlantYear = rowBreedObj.RowBreed_PlantYear;
                    CheckExist.RowBreed_TreeCount = rowBreedObj.RowBreed_TreeCount;


                }
                else if (rowBreedObj.RowBreed_Id == 0)
                {
                    context.RowBreeds.Add(rowBreedObj);
                }
                else
                {
                    errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateRowBreedForTransaction() ";
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ განახლდა: UpdateRowBreedForTransaction()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateRowBreedForTransaction()\n" + ex.Message;
                }
            }
        }
        public static void UpdateRowForTransaction(BerryManagementEntities context, Row rowObj, ref string errorMessage)
        {
            try
            {

                Row CheckExist = context.Rows.Where(e => e.Row_Id == rowObj.Row_Id).FirstOrDefault();


                Row CheckExist1 = context.Rows.Where(e => e.Sector_Number == rowObj.Sector_Number)
                .Where(e => e.Row_Number == rowObj.Row_Number)
                .Where(e => e.Row_Subrow_Number == rowObj.Row_Subrow_Number).FirstOrDefault();

                if (CheckExist != null && (CheckExist1 == null || CheckExist==CheckExist1))
                {
                    CheckExist.Row_Id = rowObj.Row_Id;
                    CheckExist.Sector_Number = rowObj.Sector_Number;
                    CheckExist.Row_Number = rowObj.Row_Number;
                    CheckExist.Row_Subrow_Number = rowObj.Row_Subrow_Number;


                }
                
                else
                {
                    errorMessage = "ჩანაწერი ვერ მოიძებნა UpdateRowForTransaction() ან მონაცემები დაემთხვა სხვა მონაცემებს";
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის განახლება ვერ მოხერხდა: UpdateRowForTransaction()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateRowForTransaction()\n" + ex.Message;
                }
            }
        }


        public static void UpdateRowBreedContainer(RowBreed rowBreeds, CompanyRow companyRows, Row row, ref string errorMessage)
        {

            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    if (rowBreeds.RowBreed_Breed_Id != 0)
                    {
                        UpdateRowBreedForTransaction(context, rowBreeds, ref errorMessage);
                    }
                    UpdateRowForTransaction(context, row, ref errorMessage);
                    
                    UpdateCompanyRowForTransaction(context, companyRows, ref errorMessage);

                    try
                    {
                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        else
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateRowBreedContainer()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateRowBreedContainer()\n" + ex.Message;
                        }
                    }
                }
            }

        }
    }
}
    
