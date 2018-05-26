using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T10_P1_1.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet()
        {
            return "Hello World";
        }
    }
}