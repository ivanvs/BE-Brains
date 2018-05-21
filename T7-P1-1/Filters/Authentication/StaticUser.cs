using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace T7_P1_1.Filters.Authentication
{
    public class StaticUser : IIdentity, IPrincipal
    {
        private string[] roles;

        public StaticUser(string name, string[] rolesList)
        {
            Name = name;
            AuthenticationType = "Basic";
            IsAuthenticated = true;
            roles = rolesList;
        }

        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public string Name { get; private set; }

        public IIdentity Identity
        {
            get { return this; }
        }

        public bool IsInRole(string role)
        {
            return roles.Any(x => x == role);
        }
    }

}