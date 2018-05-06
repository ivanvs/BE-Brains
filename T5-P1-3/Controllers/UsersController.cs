using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T5_P1_3.Models;

namespace T5_P1_3.Controllers
{
    public class UsersController : ApiController
    {
        private IEnumerable<User> GetDummyDb()
        {
            List<User> users = new List<User>();

            Address addr = new Address();
            addr.Id = 1;
            addr.Street = "Glavna Ulica 1";
            addr.City = "Novi Sad";
            addr.Country = "Srbija";

            User ue1 = new User();
            ue1.Id = 1;
            ue1.Email = "ivan@example.com";
            ue1.Name = "Ivan";
            ue1.Password = "password123";
            ue1.DateOfBirth = new DateTime();
            ue1.Address = addr;

            User ue2 = new User();
            ue2.Id = 2;
            ue2.Email = "mladen@example.com";
            ue2.Name = "Mladen";
            ue2.Password = "password456";
            ue2.DateOfBirth = new DateTime();
            ue2.Address = addr;

            addr.Users.Add(ue1);
            addr.Users.Add(ue2);

            users.Add(ue1);
            users.Add(ue2);

            return users;
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                if (id == 5)
                {
                    throw new Exception("User with ID == 5 doesn't exist");
                }

                User user = GetDummyDb().FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

    }
}
