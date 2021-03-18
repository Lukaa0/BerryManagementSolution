using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.HR.Security
{
    class Delete
    {
        public static void DeleteRolesPermissionByRoleId(long roleId)
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
                throw new Exception("ჩანაწერის წაშლა ვერ მოხერხდა:\n" + ex.Message);
            }
        }
    }
}
