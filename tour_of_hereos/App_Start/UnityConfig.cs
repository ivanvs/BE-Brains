using System.Data.Entity;
using System.Web.Http;
using tour_of_hereos.Models;
using tour_of_hereos.Repositories;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace tour_of_hereos
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepository<Hero>, GenericRepository<Hero>>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}