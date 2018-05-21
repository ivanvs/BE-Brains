﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using T7_P1_3.Handlers;

namespace T7_P1_3
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

            config.MessageHandlers.Add(new AuthenticationDispatcher());
        }
    }
}
