using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Ginilytics.Api.Controllers;
using Ginilytics.Service.Services.Contract;
using System;
using System.Threading.Tasks;
using Xunit;


namespace Ginilytics.UnitTest.Api.UnitTests
{
    public class HealthCheckControllerUnitTests
    {

        private readonly Mock<IHealthCheckService> _healthCheckService;
        private readonly HealthCheckController _sut;
        private readonly Mock<ILogger<HealthCheckController>> _logger;

        public HealthCheckControllerUnitTests()
        {
            _healthCheckService = new Mock<IHealthCheckService>();
            _logger = new Mock<ILogger<HealthCheckController>>();

            _sut = new HealthCheckController(_logger.Object, _healthCheckService.Object);
        }

        #region Get
        [Fact]
        public async Task Get_ServiceThrows_ShouldThrow()
        {
            _healthCheckService.Setup(x => x.CheckServiceHealthAsync()).Throws<Exception>();
            await Assert.ThrowsAsync<Exception>(() => { return _sut.GetHealthStatus(); });
        }
        [Fact]
        public async Task Get_ServiceDoesnotThrows_ShouldNotThrow()
        {
            _healthCheckService.Setup(x => x.CheckServiceHealthAsync());
            try
            {
                var result = await _sut.GetHealthStatus();
                Assert.IsType<OkObjectResult>(result);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public async Task Get_ServiceReturnsList_ShouldReturnSuccess()
        {
            _healthCheckService.Setup(x => x.CheckServiceHealthAsync()).ReturnsAsync(DateTime.Now);
            var result = await _sut.GetHealthStatus();
            Assert.IsType<OkObjectResult>(result);
        }

        #endregion


    }
}