using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Ginilytics.Api.Startup.Setup.Installers.Contracts;

namespace Ginilytics.Api.Startup.Setup.Installers
{
    public class MvcInstaller : IInstaller
    {
        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                //options.Filters.Add(typeof(CustomAuthorizationFilter));
            })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}