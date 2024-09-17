using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.Services.Contract
{
    public interface IHealthCheckService
    {
        public Task<DateTime> CheckServiceHealthAsync();
        public Task<string> GetErrorLogCheck();
    }
}