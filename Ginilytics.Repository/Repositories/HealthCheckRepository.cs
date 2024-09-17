using Ginilytics.Common.ServiceInstallers.Attributes;
using Ginilytics.Repository.Repositories.Contracts;
using Ginilytics.Repository.Setup.Contract;

namespace Ginilytics.Repository.Repositories
{
    [SingletonService]
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly IDbProvider _dbProvider;
        public HealthCheckRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }


        public async Task<DateTime> CheckHealthAsync()
        {
            return await _dbProvider.ExecuteScalarAsync<DateTime>("SELECT GETDATE()", commandType: System.Data.CommandType.Text);
        }
    }
}