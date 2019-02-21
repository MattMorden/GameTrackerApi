using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace GameTracker.Api.App_Start
{
    /// <summary>
    /// Resolves dependencies using Unity.
    /// </summary>
    public class UnityDependencyResolver : IDependencyResolver
    {
        protected IUnityContainer _unityContainer;

        /// <summary>
        /// Constructs object.
        /// </summary>
        /// <param name="container"></param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            _unityContainer = container;
        }

        /// <inheritdoc />
        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        /// <inheritdoc />
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        /// <inheritdoc />
        public IDependencyScope BeginScope()
        {
            var child = _unityContainer.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _unityContainer.Dispose();
        }
    }
}