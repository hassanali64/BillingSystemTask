using BillingSystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BillingSystemTask
{
    public class Role : RoleProvider
    {

        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (DB db = new DB())
            {
                var user = db.Users.Include("Role").Where(a => a.Email == username).FirstOrDefault().Role.RoleName;
                string[] role = { user };
                return role;
            }
           /* using (DB db = new DB())
            {
                var user = db.Users.Include("Role").Where(a => a.Email == username).FirstOrDefault();

                if (user != null && user.Role != null)
                {
                    string[] role = { user.Role.RoleName };
                    return role;
                }

                // If user or user.Role is null, return an empty array
                return new string[0];
            }*/








        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}