using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security
{
    public class Insert
    {
        public static long InsertRole(Role role, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                    result = role.Role_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertRole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertRole()\n" + ex.Message;
                }
            }
            return result;
        }
        public static long InsertRolesPermission(RolePermission rolesPermission)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.RolePermissions.Add(rolesPermission);
                    context.SaveChanges();
                    result = rolesPermission.RolePermission_Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ჩანაწერის დაფიქსირება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static void InsertRolesPermissionsList(List<RolePermission> rolesPermissionsList, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    foreach (RolePermission rolePermission in rolesPermissionsList)
                    {
                        context.RolePermissions.Add(rolePermission);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertRolesPermissionsList()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertRolesPermissionsList()\n" + ex.Message;
                }
            }
        }
        public static bool InsertPostRole(PostRole postRole, ref string errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.PostRoles.Add(postRole);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertPostRole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertPostRole()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void InsertUser(User user, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertUser()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertUser()\n" + ex.Message;
                }
            }
        }
    }
   
}
