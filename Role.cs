using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAdministration_
{
    internal class Role
    {
        private RoleType role;
        public Role() { }
        public Role(RoleType role) { this.role = role; }
        public Role(string role) { if (!string.IsNullOrWhiteSpace(role)) this.role = Parse(role); else throw new ArgumentNullException(role, "Argument null or white space!"); }
        public enum RoleType
        {
            None,
            MainAdmin,
            Admin,
            Manager,
            User
        }
        public static RoleType Parse(string role)
        {
            if (role is null)
                throw new ArgumentNullException(role, "Argument is null!");
            RoleType role;
            
            return role.Trim().ToLower() switch
            {
                "mainadmin" or "main_admin" => RoleType.MainAdmin,
                "admin" => RoleType.Admin,
                "manager" => RoleType.Manager,
                "user" => RoleType.User,
                _ => RoleType.None
            };
        }
        public RoleType GetRole() { return this.role; }
        public void SetRole(RoleType role) { this.role = role; }
        public void SetRole(string role) { if (!string.IsNullOrWhiteSpace(role)) this.role = Parse(role); else throw new ArgumentNullException(role, "Argument null or white space!"); }
        public override string ToString() => this.role.ToString();
    }
}
