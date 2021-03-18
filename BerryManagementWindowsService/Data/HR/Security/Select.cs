using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.HR.Security
{
    class Select
    {
        public static List<Data.RolePermission> GetPermissionsForRole(long roleId)
        {
            List<Data.RolePermission> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = (from p in context.Permissions
                              join rp in (from a in context.RolePermissions where a.RolePermission_Id == roleId select a) on p.Permission_Id equals rp.RolePermission_Permission_Id into joined
                              from rp in joined.DefaultIfEmpty()
                              orderby p.Permission_ParentId, p.Permission_Name
                              select new Data.RolePermission
                              {
                                  RolePermission_Id = p.Permission_Id,
                                  RolePermission_Role_Id = (rp == null) ? 0 : rp.RolePermission_Role_Id,
                                  RolePermission_Permission_Id = (rp == null) ? 0 : rp.RolePermission_Permission_Id,
                              }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }
    }
}
