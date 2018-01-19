using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CleanArchitecture.Infraestructure.CrossCutting
{
    public static class IoCHelper
    {
        public static WindsorContainer Container { get; private set; }

        private static WindsorDependencyResolver resolver;
        private static bool initialized;

        static IoCHelper()
        {
            Container = new WindsorContainer();
            initialized = false;
        }

        public static WindsorDependencyResolver GetDependencyResolver()
        {
            if (initialized)
                return resolver;
            
            initialized = true;
            Container.Install(FromAssembly.This());
            resolver = new WindsorDependencyResolver(Container);

            return resolver;
        }
    }
}