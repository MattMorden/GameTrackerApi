using GameTracker.Api.App_Start;
using GameTracker.Api.Controllers;
using GameTracker.Api.Data.IRepositories;
using GameTracker.Api.Data.Repositories;
using GameTracker.Api.Services.IServices;
using GameTracker.Api.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;

namespace GameTracker.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Setup Dependency Injection
            config.DependencyResolver = GetDependencyResolver(config);

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        /// <summary>
        /// Gets the Unity Dependency Resolver.
        /// </summary>
        /// <param name="configuration">The HttpConfiguration object.</param>
        /// <returns>IDependencyResolver</returns>
        private static IDependencyResolver GetDependencyResolver(HttpConfiguration configuration)
        {
            IUnityContainer unityContainer = new UnityContainer();

            // Resolve Libraries

            // Resolve Services & Mappers
            unityContainer.RegisterType<INhlService, NhlService>();

            // Resolve Repositories
            unityContainer.RegisterType<INhlRepository, NhlRepository>();

            // Return Dependency Resolver
            return new UnityDependencyResolver(unityContainer);
        }
    }
}
