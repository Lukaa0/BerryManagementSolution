using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Security_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Security_Service
    {
        #region Select
        [OperationContract]
        List<Data.Permission> GetPermissions(long? permissionId, List<long> permissionIds,
            long? permissionParentId, List<long> permissionParentIds, ref string errorMessage);

        [OperationContract]
        Data.Security.DataClasses.UserPermissions GetUserPermissions(long userId, ref string errorMessage);

        [OperationContract]
        List<Data.Security.DataClasses.UserModel> AutorizeUser(string code, string userPersonalNumber, string userBarCode, ref string errorMessage);

        [OperationContract]
        List<Data.Role> GetRoles(long? roleId, List<long> roleIds, ref string errorMessage);

        [OperationContract]
        List<Data.RolePermission> GetRolePermissions(long? rolePermissionId, List<long> rolePermissionIds,
            long? rolePermissionRoleId, List<long> rolePermissionRoleIds, long? rolePermissionPermissionId, List<long> rolePermissionPermissionIds,
            ref string errorMessage);
        [OperationContract]
        List<Data.Security.DataClasses.PermissionsForRole> GetPermissionsForRole(long? roleId, ref string errorMessage);

        [OperationContract]
        List <Data.Security.DataClasses.UserModel> GetUsers(long? userId, string userFirstName, string userLastName, bool? userIsActive,
            string userPersonalNumber, string userBarCode, ref string errorMessage);

        [OperationContract]
        List<Data.Security.DataClasses.UserModel> GetUsersModel(long? userId, string userFirstName, string userLastName, bool? userIsActive,
            string userPersonalNumber, string userBarCode, ref string errorMessage);

        [OperationContract]
        bool GetPost_Post_Id(long PostId, ref string errorMessage);

        [OperationContract]
        List<Data.Security.DataClasses.PostRoleName> GetPostRoles(ref string errorMessage);

        [OperationContract]
        List<Data.Role> GetAllRoles(ref string errorMessage);

        [OperationContract]
        List<Data.Post> GetAllPost(ref string errorMessage);


        #endregion Select

        #region Insert
        [OperationContract]
        long InsertRole(Data.Role role, ref string errorMessage);
        [OperationContract]
        void InsertRolesPermissionsList(List<Data.RolePermission> rolesPermissionsList, ref string errorMessage);
        [OperationContract]
        bool InsertPostRole(Data.PostRole postRole, ref string errorMessage);
        [OperationContract]
        void InsertUser(Data.User user, ref string errorMessage);
        [OperationContract]
        bool CheckUser(long PersonId, ref string errorMessage);
        [OperationContract]
        bool CheckPostRole(long PostId, ref string errorMessage);


        #endregion Insert

        #region Update
        [OperationContract]
        void UpdateRole(Data.Role role, ref string errorMessage);
        [OperationContract]
        void UpdateRolePost(Data.PostRole postrole, ref string errorMessage);

        [OperationContract]
        void UpdatePostRole(long Id, long Post_Id, long Role_Id, DateTime StartDate, DateTime EndDate, ref string errorMessage);

        [OperationContract]
        void UpdateUser(long Id, String passWord,bool isAdmin, ref string errorMessage);
        #endregion Update

        #region Delete
        [OperationContract]
        void DeleteRole(long roleId, ref String errorMessage);
        [OperationContract]
        void DeleteRolesPermissionByRoleId(long roleId, ref string errorMessage);
        [OperationContract]
        bool DeletePostRoleById(long roleId, ref string errorMessage);


        #endregion Delete
    }
}
