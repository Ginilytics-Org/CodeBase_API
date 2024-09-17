namespace Ginilytics.Repository.Repositories.Contracts
{
    public interface IHealthCheckRepository
    {
        public Task<DateTime> CheckHealthAsync();

    }
}