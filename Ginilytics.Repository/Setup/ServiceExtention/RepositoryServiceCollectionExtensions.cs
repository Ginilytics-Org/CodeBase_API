using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Common.ServiceInstallers.Extentions;
using Ginilytics.Repository.Setup.Contract;
using Ginilytics.Repository.Setup.Provider;
using Ginilytics.Repository.Setup.ServiceExtention.Configuration;
using System.Reflection;

namespace Ginilytics.Repository.Setup.ServiceExtention
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, DapperOptions dapperOptions) => ResolveDbProviders(services, dapperOptions);

        private static IServiceCollection ResolveDbProviders(IServiceCollection services, DapperOptions dapperOptions)
        {
            services.RegisterApplicationServices(Assembly.GetExecutingAssembly());
            services.Add(ServiceDescriptor.Describe(typeof(IDbProvider), (provider) =>
            {
                return new DbProvider(dapperOptions.ConnectionString);
            }, dapperOptions.Lifetime));

            return services;
        }


    }
}