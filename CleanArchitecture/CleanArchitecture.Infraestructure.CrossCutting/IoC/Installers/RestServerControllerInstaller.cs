using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CleanArchitecture.Infraestructure.CrossCutting.IoC.Installers
{
    public class RestServerControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("CleanArchitecture.RestServer")
                     .BasedOn<ApiController>()
                     .LifestyleScoped());
        }
    }
}
