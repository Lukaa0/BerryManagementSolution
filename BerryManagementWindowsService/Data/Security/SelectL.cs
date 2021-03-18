using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Security
{
    public static class SelectL
    {

        public static List<Data.Permission> GetPermissions(long? permissionId, List<long> permissionIds,
            long? permissionParentId, List<long> permissionParentIds, ref string errorMessage)
        {
            List<Data.Permission> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.SelectPermissions(context, permissionId, permissionIds,
                        permissionParentId, permissionParentIds, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPermissions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPermissions()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Role> GetRoles(long? roleId, List<long> roleIds, ref string errorMessage)
        {
            List<Data.Role> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.SelectRoles(context, roleId, roleIds, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRoles()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRoles()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.RolePermission> GetRolePermissions(long? rolePermissionId, List<long> rolePermissionIds,
            long? rolePermissionRoleId, List<long> rolePermissionRoleIds, long? rolePermissionPermissionId, List<long> rolePermissionPermissionIds,
            ref string errorMessage)
        {
            List<Data.RolePermission> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.SelectRolePermissions(context, rolePermissionId, rolePermissionIds, rolePermissionRoleId, rolePermissionRoleIds,
                        rolePermissionPermissionId, rolePermissionPermissionIds, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRolePermissions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRolePermissions()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Security.DataClasses.PermissionsForRole> GetPermissionsForRole(long? roleId, ref string errorMessage)
        {
            List<Data.Security.DataClasses.PermissionsForRole> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPermissionsForRole(context, roleId, ref errorMessage);
                    result = selectText.ToList();
                }


            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPermissionsForRole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPermissionsForRole()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Security.DataClasses.UserModel> GetUsers(long? userId, string userFirstName, string userLastName, bool? userIsActive,
            string personalNumber, string userBarCode, string password, ref string errorMessage)
        {
            List<Data.Security.DataClasses.UserModel> result = null;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                //selectText არის select-ის ტექსტი, 
                var selectText = SelectQ.GetUsers(context, userId, userFirstName, userLastName, userIsActive, personalNumber, userBarCode, password, ref errorMessage);

                result = selectText.ToList();
            }
            return result;
        }

        public static List<Data.Security.DataClasses.UserModel> GetUsersModel(long? userId, string userFirstName, string userLastName, bool? userIsActive,
    string personalNumber, string userBarCode, string password, ref string errorMessage)
        {
            List<Data.Security.DataClasses.UserModel> result = null;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                //selectText არის select-ის ტექსტი, 
                var selectText = SelectQ.GetUsersModel(context, userId, userFirstName, userLastName, userIsActive, personalNumber, userBarCode, password, ref errorMessage);

                result = selectText.ToList();
            }
            return result;
        }

        public static List<DataClasses.UserModel> AutorizeUser(string code, string userId, string userBarCode, ref string errorMessage)
        {
            List<DataClasses.UserModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.AutorizeUser(context, code, userId, userBarCode, ref errorMessage);
                    var v = selectText.ToList();
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: AutorizeUser()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: AutorizeUser\n" + ex.Message;
                }
            }
            return result;

        }
        public static bool CheckPostRole(long PostId, ref string errorMessage)
        {
            bool result = false;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    if (context.PostRoles.Any(o => o.PostRole_Post_Id == PostId && (o.PostRole_EndDate > DateTime.Now || o.PostRole_EndDate == null)))
                        result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckPostRole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckPostRole()\n" + ex.Message;
                }
            }
            return result;
        }
        public static bool GetPost_Post_Id(long PostId, ref string errorMessage)
        {
            bool result = false;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    if (context.PostRoles.Any(o => o.PostRole_Post_Id == PostId && o.PostRole_EndDate < DateTime.Now))
                        result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPostRole_Id()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPostRole_Id()\n" + ex.Message;
                }
            }
            return result;
        }

        public static bool CheckUser(long PersonId, ref string errorMessage)
        {
            bool result = false;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    if (context.Users.Any(o => o.User_Person_Id == PersonId))
                        result = true;
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckUser()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckUser()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Security.DataClasses.PostRoleName> GetPostRoles(ref string errorMessage)
        {
            List<Data.Security.DataClasses.PostRoleName> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPostRoles(context, ref errorMessage);

                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPostRoles()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPostRoles\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Role> GetAllRoles(ref string errorMessage)
        {
            List<Data.Role> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetAllRoles(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetAllRoles()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetAllRoles\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Post> GetAllPosts(ref string errorMessage)
        {
            List<Data.Post> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetAllPosts(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetAllPosts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetAllPosts\n" + ex.Message;
                }
            }
            return result;
        }

        public static Security.DataClasses.UserPermissions GetUserPermissions(long userId, ref string errorMessage)
        {
            Security.DataClasses.UserPermissions result = new DataClasses.UserPermissions();
            result.UserId = userId;
            List<long> permissions = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var text = SelectQ.GetUserPermissions(context, userId, ref errorMessage);
                    permissions = text.ToList();
                    result = new DataClasses.UserPermissions();
                    result.UserId = userId;
                    result.UserPermisions = permissions;
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetUserPermissions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetUserPermissions()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
