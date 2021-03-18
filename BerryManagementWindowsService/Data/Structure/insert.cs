using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure
{
    class insert
    {
        public static long InsertPersonPost(PersonPost PersonPost, ref String errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.PersonPosts.Add(PersonPost);
                    context.SaveChanges();
                    result = PersonPost.PersonPost_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertPersonPost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertPersonPoste()\n" + ex.Message;
                }
            }
            return result;
        }



        public static void InsertBrigades(Brigade Brigades, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Brigades.Add(Brigades);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertBrigades()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertBrigades)\n" + ex.Message;
                }
            }
        }


        public static void InsertCarDriver(CarDriver CarDrivers, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.CarDrivers.Add(CarDrivers);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertCarDriver()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertCarDriver()\n" + ex.Message;
                }
            }
        }



        public static void InsertCar(Car car, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Cars.Add(car);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertCar()\n" + ex.Message;
                }
            }
        }


        public static void InsertCompanyCar(CompanyCar compCar, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.CompanyCars.Add(compCar);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertCompanyCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertCompanyCar()\n" + ex.Message;
                }
            }
        }


        public static void InsertCompany(Companye company, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Companyes.Add(company);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertCompany()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertCompany()\n" + ex.Message;
                }
            }
        }


        public static void InsertCompanyRow(CompanyRow companyRow, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.CompanyRows.Add(companyRow);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertCompanyRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertCompanyRow()\n" + ex.Message;
                }
            }
        }



        public static void InsertPoint(Point point, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Points.Add(point);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertPoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertPoint()\n" + ex.Message;
                }
            }
        }


        public static void InsertPost(Post post, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Posts.Add(post);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertPost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertPost()\n" + ex.Message;
                }
            }
        }


        public static void InsertRowBreed(RowBreed rowBreed, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.RowBreeds.Add(rowBreed);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertRowBreed()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertRowBreed()\n" + ex.Message;
                }
            }
        }

        public static void InsertRow(Row row, ref String errorMessage)
        {
            try
            {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Row CheckExist1 = context.Rows.Where(e => e.Sector_Number == row.Sector_Number)
                    .Where(e => e.Row_Number == row.Row_Number)
                    .Where(e => e.Row_Subrow_Number == row.Row_Subrow_Number).FirstOrDefault();

                    //if (CheckExist1 != null)
                    //{
                    //    errorMessage = "შეყვანილი ინფორმაცია არ არის უნიკულარი";
                    //}
                    //else
                    //{
                        context.Rows.Add(row);
                        context.SaveChanges();
                    //}

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertRow()\n" + ex.Message;
                }
            }
        }

        public static long InsertRowForTransaction(BerryManagementEntities context, Row row, ref string errorMessage)
        {
            long result = 0;
            try
            {
                Row CheckExist1 = context.Rows.Where(e => e.Sector_Number == row.Sector_Number)
                .Where(e => e.Row_Number == row.Row_Number)
                .Where(e => e.Row_Subrow_Number == row.Row_Subrow_Number).FirstOrDefault();

                if (CheckExist1 != null)
                {
                    errorMessage = "შეყვანილი ინფორმაცია არ არის უნიკულარი";
                }
                else
                {
                    context.Rows.Add(row);
                    context.SaveChanges();
                    result = row.Row_Id;
                }


            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertRowForTransaction()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertRowForTransaction()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void InsertRowBreedForTransaction(BerryManagementEntities context, RowBreed rowBreed, ref String errorMessage)
        {
            try
            {

                context.RowBreeds.Add(rowBreed);



            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertRowBreedForTransaction()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertRowBreedForTransaction()\n" + ex.Message;
                }
            }
        }

        public static void InsertCompanyRowForTransaction(BerryManagementEntities context, CompanyRow companyRow, ref String errorMessage)
        {
            try
            {

                context.CompanyRows.Add(companyRow);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertCompanyRowForTransaction()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n InsertCompanyRowForTransaction()\n" + ex.Message;
                }
            }
        }

        public static void InsertRowBreedContainer(RowBreed rowBreeds, CompanyRow companyRows, Row row, ref string errorMessage)
        {

            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    long Row_ID = InsertRowForTransaction(context, row, ref errorMessage);
                    rowBreeds.RowBreed_Row_Id = Row_ID;
                    companyRows.CompanyRow_Row_Id = Row_ID;
                    if (rowBreeds.RowBreed_Breed_Id != 0)
                    {
                        InsertRowBreedForTransaction(context, rowBreeds, ref errorMessage);
                    }
                    
                    InsertCompanyRowForTransaction(context, companyRows, ref errorMessage);

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
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  InsertRowBreedContainer()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  InsertRowBreedContainer()\n" + ex.Message;
                        }
                    }
                }
            }

        }
    }
}
