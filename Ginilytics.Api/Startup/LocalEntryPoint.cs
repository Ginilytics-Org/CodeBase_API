using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Ginilytics.Api.Startup;

namespace Ginilytics.Api.Startup
{
    public class LocalEntryPoint
    {
        public static void Main(string[] args)
        {
            RunHostBuilder(args).Build().Run();
        }

        public static IHostBuilder RunHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}