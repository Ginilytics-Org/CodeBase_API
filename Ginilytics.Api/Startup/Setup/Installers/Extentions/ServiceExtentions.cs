using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Api.Startup.Configuration;
using Ginilytics.Api.Startup.Setup.Installers.Contracts;

namespace Ginilytics.Api.Startup.Setup.Installers.Extentions
{
    public static class ServiceExtentions
    {
        public static void InstallConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfiguration>(configuration);
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var registeredServices = typeof(ServiceExtentions).Assembly
                        .ExportedTypes.Where(
                            x => typeof(IInstaller).IsAssignableFrom(x)
                                && !x.IsInterface
                                && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IInstaller>()
                        .ToList();

            registeredServices.ForEach(x => x.ConfigureServices(services, configuration));
        }
    }
}