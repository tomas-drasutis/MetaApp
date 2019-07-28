using Autofac;
using Metaapp.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Metaapp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<WeatherController>().As<IWeatherController>();
            builder.RegisterType<WeatherDisplayer>().As<IWeatherDisplayer>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Metaapp)))
                .Where(t => t.Namespace.Contains("DataLayer"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Metaapp)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
