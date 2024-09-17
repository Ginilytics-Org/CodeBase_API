using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Repository.Setup.ServiceExtention;
using Ginilytics.Repository.Setup.ServiceExtention.Configuration;
using Ginilytics.Service.Setup.ServiceInstallers.Configuration;
using Ginilytics.Service.Setup.ServiceInstallers.Contracts;

namespace Ginilytics.Service.Setup.ServiceInstallers
{
    internal class RepositoryInstaller : IServiceInstaller
    {
        void IServiceInstaller.ConfigureServices(IServiceCollection services, ServiceConfig configuration) =>
            services.AddDbContext(new DapperOptions
            {
                ConnectionString = configuration.ConnectionString,
                Lifetime = configuration.Lifetime
            });
    }
}