using Moq;
using Ginilytics.Repository.Repositories;
using Ginilytics.Repository.Setup.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ginilytics.UnitTest.Repository.UnitTests
{
    public class HealthCheckRepositoryUnitTests
    {
        private readonly HealthCheckRepository _sut;
        private readonly Mock<IDbProvider> _dbProvider;

        public HealthCheckRepositoryUnitTests()
        {
            _dbProvider = new Mock<IDbProvider>();
            _sut = new HealthCheckRepository(_dbProvider.Object);
        }


        #region CheckHealthAsync
        [Fact]
        private async Task CheckHealthAsync_DbThrows_ShouldThrow()
        {
            _dbProvider.Setup(x => x.ExecuteScalarAsync<DateTime>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<System.Data.CommandType>())).Throws<Exception>();
            await Assert.ThrowsAsync<Exception>(() => { return _sut.CheckHealthAsync(); });
        }

        [Fact]
        private async Task CheckHealthAsync_DbDoesnotThrows_ShouldNotThrow()
        {
            _dbProvider.Setup(x => x.ExecuteScalarAsync<DateTime>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<System.Data.CommandType>()));
            try
            {
                var result = await _sut.CheckHealthAsync();
                Assert.Equal(DateTime.MinValue, result);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public async Task CheckHealthAsync_RepoReturnsDate_ShouldReturn()
        {
            var expectedResult = DateTime.Now;
            _dbProvider.Setup(x => x.ExecuteScalarAsync<DateTime>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<System.Data.CommandType>())).ReturnsAsync(expectedResult);
            var result = await _sut.CheckHealthAsync();
            Assert.Equal(expectedResult, result);
        }
        #endregion

    }
}