using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T6_P1_1.Filters;
using T6_P1_1.Models;

namespace T6_P1_1.Controllers
{
    public class UsersController : ApiController
    {
        [ValidateModel]
        public HttpResponseMessage PostUser(User user)
        {
            //We don't need this if we have filter for validation
            /*if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }*/
            return Request.CreateResponse(HttpStatusCode.Accepted, user);
        }
    }
}
