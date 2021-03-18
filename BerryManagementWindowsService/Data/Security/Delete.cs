using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security
{
    public static class Delete
    {
        public static void DeleteRole(long roleId, ref String errorMessage)
        {
            string error = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Role roleD = SelectQ.SelectRoles(context, roleId, null, ref error).FirstOrDefault();
                    if (!string.IsNullOrEmpty(error))
                    {
                        throw new Exception(error);
                    }
                    //var RolePermissions = SelectQ.SelectRolePermissions(context, null, null, role.RoleId, null, null, null, ref error);
                    //if (!string.IsNullOrEmpty(error))
                    //{
                    //    throw new Exception(error);
                    //}
                    //if (RolePermissions.Count() > 0)
                    //{
                    //    throw new Exception("ჩანაწერის წაშლა არ შეიძლება, რადგან მას გაწერილი აქვს უფლებები!");
                    //}
                    if (roleD != null)
                    {
                        context.Roles.Remove(roleD);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის პოვნა მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteRole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: DeleteRole()\n" + ex.Message;
                }
            }
        }

        public static void DeleteRolesPermissionByRoleId(long roleId, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.RolePermissions.RemoveRange(context.RolePermissions.Where(rp => rp.RolePermission_Role_Id == roleId));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeleteRolesPermissionByRoleId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: DeleteRolesPermissionByRoleId()\n" + ex.Message;
                }
            }
        }

        public static bool DeletePostRoleById(long roleId, ref string errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.PostRoles.RemoveRange(context.PostRoles.Where(rp => rp.PostRole_Id == roleId));
                    context.SaveChanges();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeletePostRoleById()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: DeletePostRoleById()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
