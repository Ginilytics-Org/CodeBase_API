using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Service.Setup.ServiceInstallers.Configuration;

namespace Ginilytics.Service.Setup.ServiceInstallers.Contracts
{
    internal interface IServiceInstaller
    {
        internal void ConfigureServices(IServiceCollection services, ServiceConfig configuration);
    }
}