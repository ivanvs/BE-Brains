using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T7_P1_3.Models;

namespace T7_P1_3.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private List<User> GetDummyDb()
        {
            Role adminRole = new Role();
            adminRole.Id = 1;
            adminRole.Name = "admin";

            List<User> users = new List<User>();

            User u1 = new User();
            u1.Id = 1;
            u1.FirstName = "Ivan";
            u1.LastName = "Vasiljevic";
            u1.Email = "ivan@example.com";
            u1.Role = adminRole;

            User u2 = new User();
            u2.Id = 2;
            u2.FirstName = "Mladen";
            u2.LastName = "Kanostrevac";
            u2.Email = "mladen@example.com";
            u2.Role = adminRole;

            adminRole.Users.Add(u1);
            adminRole.Users.Add(u2);

            users.Add(u1);
            users.Add(u2);

            return users;
        }

        [Route("private")]
        //[BasicAuthentication]
        //uncomment if authentication dispatcher is not used
        [Authorize(Roles = "admins")]
        public List<User> GetUsers()
        {
            return GetDummyDb();
        }

        [Route("super-admin")]
        //[BasicAuthentication]
        //uncomment if authentication dispatcher is not used
        [Authorize(Roles = "super_admins")]
        public List<User> GetUsersSuperAdmin()
        {
            return GetDummyDb();
        }

        [Route("public")]
        [HttpGet]
        [AllowAnonymous]
        public List<User> GetUsersPublic()
        {
            return GetDummyDb();
        }
    }
}
