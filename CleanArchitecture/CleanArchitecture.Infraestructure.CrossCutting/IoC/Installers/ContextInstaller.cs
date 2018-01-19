using CleanArchitecture.Infraestructure.Data;
using CleanArchitecture.Infraestructure.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CleanArchitecture.Infraestructure.CrossCutting.IoC.Installers
    
{
    public class ContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                   .For(typeof(IMongoConfiguration))
                   .ImplementedBy(typeof(MongoConfiguration))
                   .LifestyleScoped());

            container.Register(Component
                   .For(typeof(IDataContext))
                   .ImplementedBy(typeof(DataContext))
                   .LifestyleScoped());
        }
    }
}