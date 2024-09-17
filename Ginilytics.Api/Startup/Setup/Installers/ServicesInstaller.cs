using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using Ginilytics.Api.Startup.Setup.Installers.Contracts;

namespace Ginilytics.Api.Startup.Setup.Installers
{
    public class ServicesInstaller : IInstaller
    {
        void IInstaller.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            AddLogger(services, configuration);
            AddSwagger(services);
            AddCors(services, configuration);
        }


        private static void AddSwagger(IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ginilytics.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                      {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()}
                        });
            });

        private static void AddLogger(IServiceCollection services, IConfiguration configuration)
        {
            var logLevel = (Microsoft.Extensions.Logging.LogLevel)Enum.Parse(typeof(Microsoft.Extensions.Logging.LogLevel), configuration.GetSection("Logging:LogLevel:Default").Value);
            var nLogConfig = configuration.GetSection("NLog");

            services.AddLogging(logBuilder =>
            {
                logBuilder.ClearProviders();
                logBuilder.SetMinimumLevel(logLevel);

                LogManager.Configuration = new NLogLoggingConfiguration(nLogConfig);
                logBuilder.AddNLog(nLogConfig);
            });
        }

        private static void AddCors(IServiceCollection services, IConfiguration configuration) =>
            services.AddCors(options =>
            {
                options.AddPolicy(configuration.GetSection("CorsSettings:DefaultPolicyName").Value,
                    builder => builder.WithOrigins(configuration.GetSection("CorsSettings:ProdClientAppUrl").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    );
            });


    }
}