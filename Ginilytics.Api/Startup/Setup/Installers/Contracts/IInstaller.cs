using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ginilytics.Api.Startup.Setup.Installers.Contracts
{
    internal interface IInstaller
    {
        internal void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}