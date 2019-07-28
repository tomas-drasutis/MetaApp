using Metaapp.DataLayer.Provider;
using System;
using Autofac;

namespace Metaapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run(args);
            }

            Console.ReadKey();
        }
    }
}
