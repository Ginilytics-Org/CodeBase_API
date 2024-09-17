using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ginilytics.Api.Controllers.Base;

namespace Ginilytics.Api.Controllers
{
    public class HealthCheckController : BaseController
    {
        private readonly ILogger<HealthCheckController> _logger;
        private readonly IHealthCheckService _healthCheckService;

        public HealthCheckController(ILogger<HealthCheckController> logger, IHealthCheckService healthCheckService)
        {
            _logger = logger;
            _healthCheckService = healthCheckService;
        }

         

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetHealthStatus() =>
            Ok(await _healthCheckService.CheckServiceHealthAsync());

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetErrorLogCheck() =>
           Ok(await _healthCheckService.GetErrorLogCheck());

    }
}