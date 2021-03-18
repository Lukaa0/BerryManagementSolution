using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security.DataClasses
{
    /// <summary>
    /// კლასი PermissionsForRole. როლზე მიბმული უფლებების სია
    /// </summary>
    public class PermissionsForRole
    {
        public long RolesPermissionRoleId { set; get; }
        public long RolesPermissionPermissionId { set; get; }
        public long PermissionId { set; get; }
        public long PermissionParentId { set; get; }
        public string PermissionName { set; get; }

        public PermissionsForRole() { }

        public PermissionsForRole(long rolesPermissionRoleId, long rolesPermissionPermissionId, long permissionId, long permissionParentId, string permissionName)
        {

            this.RolesPermissionRoleId = rolesPermissionRoleId;
            this.RolesPermissionPermissionId = rolesPermissionPermissionId;
            this.PermissionId = permissionId;
            this.PermissionParentId = permissionParentId;
            this.PermissionName = permissionName;

        }
    }
}
