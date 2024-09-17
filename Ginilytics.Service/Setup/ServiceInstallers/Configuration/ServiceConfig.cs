using Microsoft.Extensions.DependencyInjection;

namespace Ginilytics.Service.Setup.ServiceInstallers.Configuration
{
    public class ServiceConfig
    {
        public string ConnectionString { get; set; }
        public ServiceLifetime Lifetime { get; set; }
    }
}