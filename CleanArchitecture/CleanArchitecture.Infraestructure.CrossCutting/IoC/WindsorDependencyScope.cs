using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace CleanArchitecture.Infraestructure.CrossCutting
{
    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer container;

        private readonly IDisposable scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            this.container = container;
            this.scope = this.container.RequireScope();
        }

        public void Dispose()
        {
            this.scope.Dispose();
        }

        public object GetService(Type serviceType)
        {         
            return this.container.Kernel.HasComponent(serviceType)
            ? this.container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }
    }
}