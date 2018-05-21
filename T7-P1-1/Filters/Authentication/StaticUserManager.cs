using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace T7_P1_1.Filters.Authentication
{
    public class StaticUserManager
    {
        private static Dictionary<string, string[]> roles;

        static StaticUserManager()
        {
            roles = new Dictionary<string, string[]>();
            roles.Add("admin", new string[] { "admins", "users" });
            roles.Add("bob", new string[] { "users" });
        }

        public static IPrincipal AuthenticateUser(string user, string pass)
        {
            if (roles.ContainsKey(user) && pass == "secret")
            {
                return new StaticUser(user, roles[user]);
            }
            return null;
        }
    }

}