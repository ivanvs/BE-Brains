using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T10_P1_1.Services;

namespace T10_P1_1.Controllers
{
    public class HomeController : ApiController
    {
        private IGreetingService service;

        public HomeController() : this(new GreetingService()) { }

        public HomeController(IGreetingService service)
        {
            this.service = service;
        }

        public string GetGreeting()
        {
            return service.Greet();
        }
    }
}
