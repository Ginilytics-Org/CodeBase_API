using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ginilytics.Api.Startup.ApplicationBuilders.Contracts;

namespace Ginilytics.Api.Startup.ApplicationBuilders.Extentions
{
    public static class ApplicationBuilderExtention
    {
        public static void BuildApplication(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            var builders = typeof(ApplicationBuilderExtention).Assembly
                        .ExportedTypes.Where(
                            x => typeof(IBuilder).IsAssignableFrom(x)
                                && !x.IsInterface
                                && !x.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IBuilder>().ToList();

            builders.ForEach(x => x.AddBuilder(app, env, configuration));
        }
    }
}