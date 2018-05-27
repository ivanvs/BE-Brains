using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using T10_P1_2_start.Models;
using T10_P1_2_start.Repositories;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

[assembly: OwinStartup(typeof(T10_P1_2_start.Startup))]
namespace T10_P1_2_start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            SetupUnity(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }

        private void SetupUnity(HttpConfiguration httpConfiguration)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<IGenericRepository<Address>, GenericRepository<Address>>();

            httpConfiguration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}