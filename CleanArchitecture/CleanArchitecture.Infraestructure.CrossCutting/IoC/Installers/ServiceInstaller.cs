using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CleanArchitecture.Api.Bootstrapper.IoC.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
          
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("CleanArchitecture.Core")
                        .Where(type => type.Name.EndsWith("Service"))
                        .WithService.DefaultInterfaces()
                        .LifestyleScoped());
        }
    }
}