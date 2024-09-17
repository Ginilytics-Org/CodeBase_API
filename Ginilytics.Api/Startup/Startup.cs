using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ginilytics.Api.Startup.ApplicationBuilders.Extentions;
using Ginilytics.Api.Startup.Setup.Installers.Extentions;
using Ginilytics.Common.ServiceInstallers.Extentions;
using Ginilytics.Service.Data.Model.Common;
using System.Reflection;
using System.Text;

namespace Ginilytics.Api.Startup
{
    public class Startup
    {
        private readonly string AllOrigins = "AllOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallConfiguration(Configuration);
            services.AddServices(Configuration);
            services.RegisterApplicationServices(Assembly.GetExecutingAssembly());

            #region Setup Auth/ Token Management
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = appSettings.JWTSecret;
            var expiry = appSettings.TokenExpiryTime;
            var issuer = appSettings.Issuer;
            var audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                };
            });
           
            #endregion

            services.AddCors(options =>
            {
                options.AddPolicy(AllOrigins,
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(AllOrigins);
            app.BuildApplication(env, Configuration);
        }
    }
}