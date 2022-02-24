using Autofac;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OA.WebApi
{
    public class ConfigureAutofac : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
<<<<<<< HEAD
            var assemblysServices = Assembly.Load("OA.Repository");

            containerBuilder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
=======
            var assemblysRepository = Assembly.Load("OA.Repository");
            containerBuilder.RegisterAssemblyTypes(assemblysRepository)
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

            var assemblysService = Assembly.Load("OA.Service");
            containerBuilder.RegisterAssemblyTypes(assemblysService)
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
>>>>>>> master
        }
    }
}
