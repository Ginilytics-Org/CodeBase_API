using Microsoft.Extensions.Logging;
using Moq;
using Ginilytics.Repository.Repositories.Contracts;
using Ginilytics.Service.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ginilytics.UnitTest.Service.UnitTests
{
    public class HealthCheckServiceUnitTests
    {
        private readonly Mock<IHealthCheckRepository> _healthCheckRepository;
        private readonly Mock<ILogger<HealthCheckService>> _mockLogger;
        private readonly HealthCheckService _sut;

        public HealthCheckServiceUnitTests()
        {
            _healthCheckRepository = new Mock<IHealthCheckRepository>();
            _mockLogger = new Mock<ILogger<HealthCheckService>>();
            _sut = new HealthCheckService(_healthCheckRepository.Object, _mockLogger.Object);
        }

        #region CheckServiceHealthAsync
        [Fact]
        public async Task CheckServiceHealthAsync_RepoThrows_ShouldThrows()
        {
            _healthCheckRepository.Setup(x => x.CheckHealthAsync()).Throws<Exception>();
            await Assert.ThrowsAsync<Exception>(() => { return _sut.CheckServiceHealthAsync(); });
        }

        [Fact]
        public async Task CheckServiceHealthAsync_RepoDoesnotThrows_ShouldNotThrows()
        {
            _healthCheckRepository.Setup(x => x.CheckHealthAsync());
            try
            {
                var result = await _sut.CheckServiceHealthAsync();
                Assert.Equal(DateTime.MinValue, result);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public async Task CheckServiceHealthAsync_RepoReturnsDate_ShouldReturn()
        {
            var testDate = DateTime.Now.AddDays(100);
            _healthCheckRepository.Setup(x => x.CheckHealthAsync()).ReturnsAsync(testDate);
            try
            {
                var result = await _sut.CheckServiceHealthAsync();
                Assert.Equal(testDate, result);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }


        #endregion


    }
}