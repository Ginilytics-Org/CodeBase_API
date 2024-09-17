using Microsoft.Extensions.DependencyInjection;

namespace Ginilytics.Repository.Setup.ServiceExtention.Configuration
{
    public class DapperOptions
    {
        public string ConnectionString { get; set; }
        public ServiceLifetime Lifetime { get; set; }
    }
}