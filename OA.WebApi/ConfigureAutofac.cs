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
            var assemblysServices = Assembly.Load("OA.Repository");

            containerBuilder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
