using Microsoft.Extensions.Logging;
using Ginilytics.Repository.Repositories.Contracts;
using Ginilytics.Service.Services.Contract;

namespace Ginilytics.Service.Services
{
    [ScopedService]
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepository;
        private readonly ILogger<HealthCheckService> _logger;
        private readonly Guid _guid;
        public HealthCheckService(IHealthCheckRepository healthCheckRepository, ILogger<HealthCheckService> logger)
        {
            _healthCheckRepository = healthCheckRepository;
            _logger = logger;
            _guid = Guid.NewGuid();
        }

        public async Task<DateTime> CheckServiceHealthAsync() =>
            await _healthCheckRepository.CheckHealthAsync();
        public async Task<string> GetErrorLogCheck()
        {
            try
            {
                _logger.LogDebug("GetErrorLogCheck is Calling");
                throw new InvalidOperationException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"HealthCheck Error: ErrorId = " + _guid);
                return "ErrorId = " + _guid.ToString();
            }
        }
    }
}