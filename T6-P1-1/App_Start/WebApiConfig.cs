using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace T6_P1_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //uncomment this line if we want all request to be validate
            //config.Filters.Add(new ValidateModelAttribute());
        }
    }
}
