using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using T7_P1_3.Infrastructure;
using T7_P1_3.Repositories;

namespace T7_P1_3.Filters.Authentication
{
    public class StaticUserManager
    {
        public static IPrincipal AuthenticateUser(string user, string pass)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var foundUser = db.UserRepository.Get(x => x.Email == user).FirstOrDefault();
                if (foundUser != null && foundUser.Password == CryptoHelper.CreatePassowrdHash(pass, foundUser.Salt))
                {
                    return new StaticUser(user, new string[] { foundUser?.Role.Name });
                }

                return null;
            }
        }

    }
}