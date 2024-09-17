using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Ginilytics.Api.Startup.ApplicationBuilders.Contracts
{
    public interface IBuilder
    {
        void AddBuilder(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration);
    }
}