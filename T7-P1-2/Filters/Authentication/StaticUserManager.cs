using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using T7_P1_2.Repositories;

namespace T7_P1_2.Filters.Authentication
{
    public class StaticUserManager
    {
        public static IPrincipal AuthenticateUser(string user, string pass)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var foundUser = db.UserRepository.Get(x => x.Email == user && x.Password == pass).FirstOrDefault();
                if (foundUser != null)
                {
                    return new StaticUser(user, new string[] { foundUser?.Role.Name });
                }

                return null;
            }
        }
    }
}