using Microsoft.Extensions.DependencyInjection;
using Ginilytics.Common.Utility;
using Ginilytics.Common.Utility.Contract;
using Ginilytics.Service.Setup.ServiceInstallers.Configuration;
using Ginilytics.Service.Setup.ServiceInstallers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.Setup.ServiceInstallers
{
    internal class UtilityInstaller : IServiceInstaller
    {
        void IServiceInstaller.ConfigureServices(IServiceCollection services, ServiceConfig configuration) =>
           services.AddScoped<IPasswordSecurity, PasswordSecurity>();
    }
}
