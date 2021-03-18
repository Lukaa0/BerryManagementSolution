using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;

namespace BerryManagementWindowsService.Data.Security
{
    public static class SelectQ
    {
        public static IQueryable<Data.Permission> SelectPermissions(BerryManagementEntities context,
            long? permissionId, List<long> permissionIds, long? permissionParentId, List<long> permissionParentIds, 
            ref string errorMessage)
        {
            IQueryable<Data.Permission> result = null;
            try
            {
                result = SelectPermissions(context);
                if (permissionId != null && permissionId > 0)
                {
                    result = result.Where(r => r.Permission_Id == permissionId);
                }
                if (permissionIds != null && permissionIds.Count > 0)
                {
                    result = result.Where(r => permissionIds.Contains(r.Permission_Id));
                }
                if (permissionParentId != null && permissionParentId > 0)
                {
                    result = result.Where(r => r.Permission_ParentId == permissionParentId);
                }
                if (permissionParentIds != null && permissionParentIds.Count > 0)
                {
                    result = result.Where(r => permissionParentIds.Contains(r.Permission_ParentId));
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: SelectPermissions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: SelectPermissions()\n" + ex.Message;
                }
            }
            finally
            { }
            return result;
        }

        public static IQueryable<Data.Permission> SelectPermissions(BerryManagementEntities context)
        {
            IQueryable<Data.Permission> result = null;
            result = context.Permissions;
            return result;
        }

        public static IQueryable<Data.Role> SelectRoles(BerryManagementEntities context,
            long? roleId, List<long> roleIds,
            ref string errorMessage)
        {
            IQueryable<Data.Role> result = null;
            try
            {
                result = SelectRoles(context);
                if (roleId != null && roleId > 0)
                {
                    result = result.Where(r => r.Role_Id == roleId);
                }
                if (roleIds != null && roleIds.Count > 0)
                {
                    result = result.Where(r => roleIds.Contains(r.Role_Id));
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: SelectRoles()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: SelectRoles()\n" + ex.Message;
                }
            }
            finally
            { }
            return result;
        }

        public static IQueryable<Data.Role> SelectRoles(BerryManagementEntities context)
        {
            IQueryable<Data.Role> result = null;
            result = context.Roles;
            return result;
        }

        public static IQueryable<Data.RolePermission> SelectRolePermissions(BerryManagementEntities context,
            long? rolePermissionId, List<long> rolePermissionIds, 
            long? rolePermissionRoleId, List<long> rolePermissionRoleIds,
            long? rolePermissionPermissionId, List<long> rolePermissionPermissionIds,
            ref string errorMessage)
        {
            IQueryable<Data.RolePermission> result = null;
            try
            {
                result = SelectRolePermissions(context);
                if (rolePermissionId !=  null && rolePermissionId > 0)
                {
                    result = result.Where(r => r.RolePermission_Id == rolePermissionId);
                }
                if (rolePermissionIds != null && rolePermissionIds.Count > 0)
                {
                    result = result.Where(r => rolePermissionIds.Contains(r.RolePermission_Id));
                }
                if (rolePermissionRoleId != null && rolePermissionRoleId > 0)
                {
                    result = result.Where(r => r.RolePermission_Role_Id == rolePermissionRoleId);
                }
                if (rolePermissionRoleIds != null && rolePermissionRoleIds.Count > 0)
                {
                    result = result.Where(r => rolePermissionRoleIds.Contains(r.RolePermission_Role_Id));
                }
                if (rolePermissionPermissionId != null && rolePermissionPermissionId > 0)
                {
                    result = result.Where(r => r.RolePermission_Permission_Id == rolePermissionPermissionId);
                }
                if (rolePermissionPermissionIds != null && rolePermissionPermissionIds.Count > 0)
                {
                    result = result.Where(r => rolePermissionPermissionIds.Contains(r.RolePermission_Permission_Id));
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: SelectRolePermissions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: SelectRolePermissions()\n" + ex.Message;
                }
            }
            finally
            { }
            return result;
        }

        public static IQueryable<Data.RolePermission> SelectRolePermissions(BerryManagementEntities context)
        {
            IQueryable<Data.RolePermission> result = null;
            result = context.RolePermissions;
            return result;
        }

           
        public static IQueryable<Data.Security.DataClasses.PermissionsForRole> GetPermissionsForRole(BerryManagementEntities context,long? roleId, ref string errorMessage)
        {
            IQueryable<Data.Security.DataClasses.PermissionsForRole> result = null;
            try
            {

                result = (from p in context.Permissions
                          join rp in (from a in context.RolePermissions where a.RolePermission_Role_Id == roleId select a) on p.Permission_Id equals rp.RolePermission_Permission_Id into joined
                          from rp in joined.DefaultIfEmpty()
                          orderby p.Permission_ParentId, p.Permission_Name
                          select new Data.Security.DataClasses.PermissionsForRole
                          {
                              PermissionId = p.Permission_Id,
                              PermissionParentId = p.Permission_ParentId,
                              PermissionName = p.Permission_Name,
                              RolesPermissionPermissionId = (rp == null) ? 0 : rp.RolePermission_Permission_Id,
                              RolesPermissionRoleId = (rp == null) ? 0 : rp.RolePermission_Role_Id
                          });
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

        public static IQueryable<Data.Security.DataClasses.UserModel> GetUsers(BerryManagementEntities context, long? userId, string userFirstName, 
            string userLastName, bool? userIsActive, string userPersonalNumber, string userBarCode, string password, ref string errorMessage)
        {
            IQueryable<Data.Security.DataClasses.UserModel> result = null;
            try
            {
                    //var entryPoint = (from user in context.Users
                    //                  join persone in context.Persons on user.User_Person_Id equals persone.Person_Id
                    //                  where (userId == null || user.User_Person_Id == userId)
                    //                  && (userFirstName == null || persone.Person_FirstName.ToLower().Contains(userFirstName.ToLower()))
                    //                  && (userLastName==null || persone.Person_LastName.ToLower().Contains(userLastName.ToLower()))
                    //                  select new Data.Security.DataClasses.UserModel
                    //                  {
                    //                     User_Person_ID=user.User_Person_Id,
                    //                     User_Person_FirstName=persone.Person_FirstName,
                    //                     User_Person_LastName=persone.Person_LastName,
                    //                     User_Password=user.User_Password,
                    //                     User_PasswordIsReset=user.User_PasswordIsReset
                    //                  });

                    //result = entryPoint;
                result = from user in context.Users
                                  join persone in context.Persons on user.User_Person_Id equals persone.Person_Id
                                  join personPost in context.PersonPosts on persone.Person_Id equals personPost.PersonPost_Person_Id
                                  join postRole in context.PostRoles on personPost.PersonPost_Post_Id equals postRole.PostRole_Post_Id
                                  where(userId == null || user.User_Person_Id == userId)
                                      && (userFirstName == null || persone.Person_FirstName.ToLower().Contains(userFirstName.ToLower()))
                                      && (userLastName == null || persone.Person_LastName.ToLower().Contains(userLastName.ToLower()))
                                      && (userIsActive == null
                                        || (userIsActive == true && personPost.PersonPost_StartDate <= DateTime.Now 
                                            && (personPost.PersonPost_EndDate == null || personPost.PersonPost_EndDate >= DateTime.Now)
                                            && postRole.PostRole_StartDate <= DateTime.Now
                                            && (postRole.PostRole_EndDate == null || postRole.PostRole_EndDate >= DateTime.Now)) 
                                        || (userIsActive == false && !(personPost.PersonPost_StartDate <= DateTime.Now
                                            && (personPost.PersonPost_EndDate == null || personPost.PersonPost_EndDate >= DateTime.Now)
                                            && postRole.PostRole_StartDate <= DateTime.Now
                                            && (postRole.PostRole_EndDate == null || postRole.PostRole_EndDate >= DateTime.Now))))
                                      && (userPersonalNumber == null || persone.Person_Identity == userPersonalNumber)
                                      && (userBarCode == null || personPost.PersonPost_EmployeeBarCode == userBarCode)
                                      && (password == null || user.User_Password == password)
                select new Data.Security.DataClasses.UserModel
                                  {
                                      User_Person_ID = user.User_Person_Id,
                                      User_Person_FirstName = persone.Person_FirstName,
                                      User_Person_LastName = persone.Person_LastName,
                                      User_Password = user.User_Password,
                                      User_PasswordIsReset = user.User_PasswordIsReset,
                                      User_PersonPost_ID = personPost.PersonPost_Id,
                                      User_Role_ID = postRole.PostRole_Role_Id,
                                      User_Brigade_ID=personPost.PersonPost_Brigade_Id.Value

                                  };
                if (userId != null)
                {

                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetUsers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetUsers()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Security.DataClasses.UserModel> GetUsersModel(BerryManagementEntities context, long? userId, string userFirstName,
    string userLastName, bool? userIsActive, string userPersonalNumber, string userBarCode, string password, ref string errorMessage)
        {
            IQueryable<Data.Security.DataClasses.UserModel> result = null;
            try
            {
                result = from user in context.Users
                         join persone in context.Persons on user.User_Person_Id equals persone.Person_Id
                         join personPost in context.PersonPosts on persone.Person_Id equals personPost.PersonPost_Person_Id
                         join postRole in context.PostRoles on personPost.PersonPost_Post_Id equals postRole.PostRole_Post_Id
                         join role in context.Roles on postRole.PostRole_Role_Id equals role.Role_Id

                         where (userId == null || user.User_Person_Id == userId)
                                      && (userFirstName == null || persone.Person_FirstName.ToLower().Contains(userFirstName.ToLower()))
                                      && (userLastName == null || persone.Person_LastName.ToLower().Contains(userLastName.ToLower()))
                                      && (userIsActive == null
                                        || (userIsActive == true && personPost.PersonPost_StartDate <= DateTime.Now
                                            && (personPost.PersonPost_EndDate == null || personPost.PersonPost_EndDate >= DateTime.Now)
                                            && postRole.PostRole_StartDate <= DateTime.Now
                                            && (postRole.PostRole_EndDate == null || postRole.PostRole_EndDate >= DateTime.Now))
                                        || (userIsActive == false && !(personPost.PersonPost_StartDate <= DateTime.Now
                                            && (personPost.PersonPost_EndDate == null || personPost.PersonPost_EndDate >= DateTime.Now)
                                            && postRole.PostRole_StartDate <= DateTime.Now
                                            && (postRole.PostRole_EndDate == null || postRole.PostRole_EndDate >= DateTime.Now))))
                                      && (userPersonalNumber == null || persone.Person_Identity == userPersonalNumber)
                                      && (userBarCode == null || personPost.PersonPost_EmployeeBarCode == userBarCode)
                                      && (password == null || user.User_Password == password)
                         select new Data.Security.DataClasses.UserModel
                         {
                             User_Person_ID = user.User_Person_Id,
                             User_Person_FirstName = persone.Person_FirstName,
                             User_Person_LastName = persone.Person_LastName,
                             User_Password = user.User_Password,
                             User_PasswordIsReset = user.User_PasswordIsReset,
                             User_PersonPost_ID = personPost.PersonPost_Id,
                             User_Role_ID = postRole.PostRole_Role_Id,
                             User_Brigade_ID = personPost.PersonPost_Brigade_Id.Value,
                             User_Role_Name = role.Role_Name

                         };
                if (userId != null)
                {

                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetUsers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetUsers()\n" + ex.Message;
                }
            }
            return result;
        }




        //public static IQueryable GetUsersRoles(BerryManagementEntities context, long? userRoleId, long? userRoleUserId, long? userRoleRoleId, ref string errorMessage)
        //{
        //    IQueryable result = null;
        //    try
        //    {
        //            result = (from ur in context.UsersRoles
        //                      join u in context.Users on ur.UserRoleUserId equals u.UserId
        //                      join r in context.Roles on ur.UserRoleRoleId equals r.RoleId
        //                      where (userRoleId == null || ur.UserRoleId == userRoleId)
        //                        && (userRoleUserId == null || ur.UserRoleUserId == userRoleUserId)
        //                        && (userRoleRoleId == null || ur.UserRoleRoleId == userRoleRoleId)
        //                      select new
        //                      {
        //                          UserRoleEndDate = ur.UserRoleEndDate,
        //                          UserRoleId = ur.UserRoleId,
        //                          UserRoleFullUserName = u.UserFullName,
        //                          UserRoleRoleDescription = r.RoleDescription,
        //                          UserRoleRoleId = ur.UserRoleRoleId,
        //                          UserRoleRoleName = r.RoleName,
        //                          UserRoleStartDate = ur.UserRoleStartDate,
        //                          UserRoleUserId = ur.UserRoleUserId,
        //                          UserRoleUserName = u.UserName
        //                      }
        //                      ).Select(ur => new UsersRole()
        //                      {
        //                          UserRoleEndDate = ur.UserRoleEndDate,
        //                          UserRoleId = ur.UserRoleId,
        //                          UserRoleFullUserName = ur.UserRoleFullUserName,
        //                          UserRoleRoleDescription = ur.UserRoleRoleDescription,
        //                          UserRoleRoleId = ur.UserRoleRoleId,
        //                          UserRoleRoleName = ur.UserRoleRoleName,
        //                          UserRoleStartDate = ur.UserRoleStartDate,
        //                          UserRoleUserId = ur.UserRoleUserId,
        //                          UserRoleUserName = ur.UserRoleUserName
        //                      });

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
        //    }
        //    return result;
        //}


        public static IQueryable<Data.Security.DataClasses.PostRoleName> GetPostRoles(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Security.DataClasses.PostRoleName> result = null;
            try
            {
                var entryPoint = from ep in context.PostRoles
                                 join ps in context.Posts on ep.PostRole_Post_Id equals ps.Post_Id
                                 join rl in context.Roles on ep.PostRole_Role_Id equals rl.Role_Id
                                 select new Data.Security.DataClasses.PostRoleName
                                 {
                                     PostRole_Id = ep.PostRole_Id,
                                     PostRole_Post_Id = ep.PostRole_Post_Id,
                                     PostRole_Role_Id = ep.PostRole_Role_Id,
                                     PostRole_Role_Name = rl.Role_Name,
                                     PostRole_Post_Name = ps.Post_Name,
                                     PostRole_Start = ep.PostRole_StartDate,
                                     PostRole_End = ep.PostRole_EndDate
                                 };

                result = entryPoint;

                //result = context.PostRoles;

                //return result;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPostRoles()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPostRoles()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Role> GetAllRoles(BerryManagementEntities context)
        {
            IQueryable<Data.Role> result = context.Roles;

            return result;
        }

        public static IQueryable<Data.Post> GetAllPosts(BerryManagementEntities context)
        {
            IQueryable<Data.Post> result = context.Posts;

            return result;
        }


        public static IQueryable<DataClasses.UserModel> AutorizeUser(BerryManagementEntities context, string password, string userPersonalNumber, 
            string userBarCode, ref string errorMessage)
        {
            IQueryable<DataClasses.UserModel> result = null;
            try
            {
                result = GetUsers(context, null, null, null, true, userPersonalNumber, userBarCode, password, ref errorMessage);
                //var entryPoint = from user in context.Users
                //                  join persone in context.Persons on user.User_Person_Id equals persone.Person_Id
                //                  join personpost in context.PersonPosts on persone.Person_Id equals personpost.PersonPost_Person_Id
                //                  where (userPersonalNumber == null || persone.Person_Identity == userPersonalNumber)
                //                    && (UserBarCode == null || personpost.PersonPost_EmployeeBarCode==UserBarCode) 
                //                    && (code == user.User_Password)
                //                  select new DataClasses.UserModel
                //                  {
                //                      User_Person_ID = user.User_Person_Id,
                //                      User_Person_FirstName = persone.Person_FirstName,
                //                      User_Person_LastName = persone.Person_LastName,
                //                      User_Password = user.User_Password,
                //                      User_PasswordIsReset = user.User_PasswordIsReset,

                //                  };

                //result = entryPoint;

                //var user = context.Users.Where(s=> )
                //if (user != null)
                //{
                //    result = new User();
                //    result.UserDescription = user.UserDescription;
                //    result.UserFullName = user.UserFullName;
                //    result.UserId = user.UserId;
                //    result.UserIsActive = user.UserIsActive;
                //    result.UserName = user.UserName;
                //    result.UserPasswordIsReset = user.UserPasswordIsReset;
                //    result.UserPassword = null;
                //}

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: AutorizeUser()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: AutorizeUser()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<long> GetUserPermissions(BerryManagementEntities context, long userId, ref string errorMessage)
        {
            
            IQueryable<long> result = null;

            try
            {

                var query = (from u in context.Persons
                             join personpost in context.PersonPosts on u.Person_Id equals personpost.PersonPost_Person_Id
                             join postRole in context.PostRoles on personpost.PersonPost_Post_Id equals postRole.PostRole_Post_Id
                             join p in context.RolePermissions on postRole.PostRole_Role_Id equals p.RolePermission_Role_Id
                             where personpost.PersonPost_StartDate <= DateTime.Today && (personpost.PersonPost_EndDate == null || personpost.PersonPost_EndDate >= DateTime.Today)
                                && postRole.PostRole_StartDate <= DateTime.Today && (postRole.PostRole_EndDate == null || postRole.PostRole_EndDate >= DateTime.Today)
                                && u.Person_Id == userId
                             select p.RolePermission_Permission_Id);
                result = query;
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
