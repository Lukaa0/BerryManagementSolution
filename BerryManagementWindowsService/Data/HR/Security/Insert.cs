using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.HR.Security
{
    class Insert
    {
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

        public static void InsertRolesPermissionsList(List<RolePermission> rolesPermissionsList)
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
                throw new Exception("ჩანაწერის დაფიქსირება ვერ მოხერხდა:\n" + ex.Message);
            }
        }
    }
}
}
