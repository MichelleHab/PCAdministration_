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
            RoleType result;
            switch (role.Trim().ToLower())
            {
                case "mainadmin":
                case "main_admin":
                    result = RoleType.MainAdmin;
                    break;
                case "admin":
                    result = RoleType.Admin;
                    break;
                case "manager":
                    result = RoleType.Manager;
                    break;
                case "user":
                    result = RoleType.User;
                    break;
                default:
                    result = RoleType.None;
                    break;

            }
            return result;
        }
        public RoleType GetRole() { return this.role; }
        public void SetRole(RoleType role) { this.role = role; }
        public void SetRole(string role) { if (!string.IsNullOrWhiteSpace(role)) this.role = Parse(role); else throw new ArgumentNullException(role, "Argument null or white space!"); }
        public override string ToString() => this.role.ToString();
    }
}
