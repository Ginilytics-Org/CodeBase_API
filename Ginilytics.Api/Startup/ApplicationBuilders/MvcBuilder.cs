using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ginilytics.Api.Startup.ApplicationBuilders.Contracts;
using Ginilytics.Api.Startup.Setup.Middlewares;

namespace Ginilytics.Api.Startup.ApplicationBuilders
{
    public class MvcBuilder : IBuilder
    {
        public void AddBuilder(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ginilytics.WebApi v1"));

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(configuration.GetSection("CorsSettings:DefaultPolicyName").Value);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}