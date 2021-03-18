using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security
{
    public class Update
    {
        public static void UpdateRole(Role role, ref string errorMessage)
        {
            string error = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Role roleT = SelectQ.SelectRoles(context, role.Role_Id, null, ref error).FirstOrDefault();
                    if (!string.IsNullOrEmpty(error))
                    {
                        throw new Exception(error);
                    }
                    if (roleT != null)
                    {
                        roleT.Role_Description = role.Role_Description;
                        roleT.Role_Name = role.Role_Name;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRole()\n" + ex.Message;
                }
            }
        }

        public static void UpdateRolePost(PostRole postrole, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var result = context.PostRoles.SingleOrDefault(b => b.PostRole_Id == postrole.PostRole_Id);
                    if (result != null)
                    {
                        result.PostRole_Post_Id = postrole.PostRole_Post_Id;
                        result.PostRole_Role_Id = postrole.PostRole_Role_Id;
                        result.PostRole_StartDate = postrole.PostRole_StartDate;
                        result.PostRole_EndDate = postrole.PostRole_EndDate;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRolePost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRolePost()\n" + ex.Message;
                }
            }
        }



        public static void UpdatePostRole(long Id, long Post_Id, long Role_Id, DateTime StartDate, DateTime EndDate, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var result = context.PostRoles.SingleOrDefault(b => b.PostRole_Id == Id);
                    if (result != null)
                    {
                        result.PostRole_Post_Id = Post_Id;
                        result.PostRole_Role_Id = Role_Id;
                        result.PostRole_StartDate = StartDate;
                        result.PostRole_EndDate = EndDate;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRolePost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRolePost()\n" + ex.Message;
                }
            }
        }


        public static void UpdateUser(long Id, String passWord,bool isAdmin, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var result = context.Users.SingleOrDefault(b => b.User_Person_Id== Id);
                    if (result != null)
                    {
                        
                        result.User_Password = passWord;
                        if (isAdmin == true)
                        {
                            result.User_PasswordIsReset = true;
                        }
                        else
                        {
                            result.User_PasswordIsReset = false;
                        }

                        
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRolePost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateRolePost()\n" + ex.Message;
                }
            }
        }




    }
}
