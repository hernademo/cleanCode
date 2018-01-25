using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.CrossCutting.IoC.Installers
{
    public class ValidatorInstaller : IWindsorInstaller
    {      
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
             Classes.FromAssemblyNamed("CleanArchitecture.Infraestructure")
             .BasedOn(typeof(AbstractValidator<>))
             .WithServiceFirstInterface()
             .LifestyleScoped());
        }
    }
}
