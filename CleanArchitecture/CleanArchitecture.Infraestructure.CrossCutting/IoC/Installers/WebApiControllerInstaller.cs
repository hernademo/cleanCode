using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;

namespace CleanArchitecture.Api.Bootstrapper.IoC.Installers
{
    public class WebApiControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            /*
            container.Register(Classes.FromAssemblyNamed("CleanArchitecture.WebApi")                      
                     .BasedOn<ApiController>()
                     .LifestylePerWebRequest());
                     */
        }
    }
}