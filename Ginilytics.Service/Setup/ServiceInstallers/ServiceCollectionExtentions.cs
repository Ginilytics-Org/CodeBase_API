using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Common.ServiceInstallers.Extentions;
using Ginilytics.Service.Setup.ServiceInstallers.Configuration;
using Ginilytics.Service.Setup.ServiceInstallers.Contracts;
using System.Reflection;

namespace Ginilytics.Service.Setup.ServiceInstallers
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection SetupServicesLayer(this IServiceCollection services, ServiceConfig serviceOptions)
        {
            ResolveServiceInstallers(services, serviceOptions);
            services.RegisterApplicationServices(Assembly.GetExecutingAssembly());

            return services;
        }

        private static void ResolveServiceInstallers(IServiceCollection services, ServiceConfig serviceOptions)
        {
            var assemblyServices = typeof(ServiceCollectionExtentions).Assembly
            .DefinedTypes.Where(
                x => typeof(IServiceInstaller).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

            assemblyServices.ForEach(x => x.ConfigureServices(services, serviceOptions));
        }

    }
}