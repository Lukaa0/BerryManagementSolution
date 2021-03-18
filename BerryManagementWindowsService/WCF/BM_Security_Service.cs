using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Security_Service" in both code and config file together.
    public class BM_Security_Service : IBM_Security_Service
    {
        #region Select
        public  List<Data.Security.DataClasses.UserModel> AutorizeUser(string code, string userPersonalNumber, string userBarCode, ref string errorMessage)
        {
             return Data.Security.SelectL.AutorizeUser(code, userPersonalNumber, userBarCode, ref errorMessage);
        }

        public  Data.Security.DataClasses.UserPermissions GetUserPermissions(long userId, ref string errorMessage)
        {
            return Data.Security.SelectL.GetUserPermissions(userId, ref errorMessage);
        }
        public List<Data.Permission> GetPermissions(long? permissionId, List<long> permissionIds,
            long? permissionParentId, List<long> permissionParentIds, ref string errorMessage)
        {
            return Data.Security.SelectL.GetPermissions(permissionId, permissionIds, permissionParentId, permissionParentIds, 
                ref errorMessage);
        }

        public List<Data.Role> GetRoles(long? roleId, List<long> roleIds, ref string errorMessage)
        {
           return Data.Security.SelectL.GetRoles(roleId, roleIds, ref errorMessage);
        }

        public List<Data.RolePermission> GetRolePermissions(long? rolePermissionId, List<long> rolePermissionIds,
            long? rolePermissionRoleId, List<long> rolePermissionRoleIds, long? rolePermissionPermissionId, List<long> rolePermissionPermissionIds,
            ref string errorMessage)
        {
            return Data.Security.SelectL.GetRolePermissions(rolePermissionId, rolePermissionIds, rolePermissionRoleId, 
                rolePermissionRoleIds, rolePermissionPermissionId, rolePermissionPermissionIds, ref errorMessage);
        }

        public List<Data.Security.DataClasses.PermissionsForRole> GetPermissionsForRole(long? roleId, ref string errorMessage)
        {
            return Data.Security.SelectL.GetPermissionsForRole(roleId, ref errorMessage);
        }

        public List<Data.Security.DataClasses.UserModel> GetUsers(long? userId, string userFirstName, string userLastName, bool? userIsActive,
            string userPersonalNumber, string userBarCode, ref string errorMessage)
        {
            return Data.Security.SelectL.GetUsers(userId,userFirstName,userLastName,userIsActive, userPersonalNumber, userBarCode, null, ref errorMessage);
        }

        public List<Data.Security.DataClasses.UserModel> GetUsersModel(long? userId, string userFirstName, string userLastName, bool? userIsActive,
    string userPersonalNumber, string userBarCode, ref string errorMessage)
        {
            return Data.Security.SelectL.GetUsersModel(userId, userFirstName, userLastName, userIsActive, userPersonalNumber, userBarCode, null, ref errorMessage);
        }

        public  bool GetPost_Post_Id(long PostId, ref string errorMessage)
        {
            return Data.Security.SelectL.GetPost_Post_Id(PostId, ref errorMessage);
        }

        public List<Data.Security.DataClasses.PostRoleName> GetPostRoles(ref string errorMessage)
        {
            return Data.Security.SelectL.GetPostRoles(ref errorMessage);
        }


        public List<Data.Role> GetAllRoles(ref string errorMessage)
        {
            return Data.Security.SelectL.GetAllRoles(ref errorMessage);
        }

        public List<Data.Post> GetAllPost(ref string errorMessage)
        {
            return Data.Security.SelectL.GetAllPosts(ref errorMessage);
        }

        public  bool CheckUser(long PersonId, ref string errorMessage)
        {
            return Data.Security.SelectL.CheckUser(PersonId, ref errorMessage);
        }
        public bool CheckPostRole(long PostId, ref string errorMessage)
        {
            return Data.Security.SelectL.CheckPostRole(PostId, ref errorMessage);
        }
        #endregion Select

        #region Insert
        public long InsertRole(Data.Role role, ref string errorMessage)
        {
            return Data.Security.Insert.InsertRole(role, ref errorMessage);
        }
        public void InsertRolesPermissionsList(List<Data.RolePermission> rolesPermissionsList, ref string errorMessage)
        {
            Data.Security.Insert.InsertRolesPermissionsList(rolesPermissionsList, ref errorMessage);
        }
        public bool InsertPostRole(Data.PostRole postRole, ref string errorMessage)
        {
            return Data.Security.Insert.InsertPostRole(postRole, ref errorMessage);
        }

        public  void InsertUser(Data.User user, ref string errorMessage)
        {
            Data.Security.Insert.InsertUser(user, ref errorMessage);
        }
        #endregion Insert

        #region Update
        public void UpdateRole(Data.Role role, ref string errorMessage)
        {
            Data.Security.Update.UpdateRole(role, ref errorMessage);
        }

        public void UpdateRolePost(Data.PostRole postrole, ref string errorMessage)
        {
           Data.Security.Update.UpdateRolePost(postrole, ref errorMessage);
        }
        public void UpdatePostRole(long Id, long Post_Id, long Role_Id, DateTime StartDate, DateTime EndDate, ref string errorMessage)
        {
            Data.Security.Update.UpdatePostRole(Id, Post_Id, Role_Id, StartDate, EndDate,ref errorMessage);
        }
        public void UpdateUser(long Id, String passWord,bool isAdmin, ref string errorMessage)
        {
            Data.Security.Update.UpdateUser(Id, passWord,isAdmin, ref errorMessage);
        }
        #endregion Update

        #region Delete
        public void DeleteRole(long roleId, ref String errorMessage)
        {
            Data.Security.Delete.DeleteRole(roleId, ref errorMessage);
        }

        public bool DeletePostRoleById(long roleId, ref string errorMessage)
        {
            return Data.Security.Delete.DeletePostRoleById(roleId, ref errorMessage);
        }
        public void DeleteRolesPermissionByRoleId(long roleId, ref string errorMessage)
        {
            Data.Security.Delete.DeleteRolesPermissionByRoleId(roleId, ref errorMessage);
        }

        #endregion Delete
    }
}
