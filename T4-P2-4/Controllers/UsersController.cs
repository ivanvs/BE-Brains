using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace T4_P2_4.Controllers
{
    public class UsersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<string> GetUsernames()
        {
            logger.Info("Requesting usernames");

            List<string> names = new List<string>();
            names.Add("Ivan");
            names.Add("Mladen");
            names.Add("Vladimir");

            return names;
        }

    }
}
