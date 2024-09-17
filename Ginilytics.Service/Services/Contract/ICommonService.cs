using Ginilytics.Service.Data.Model.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.Services.Contract
{
    public interface ICommonService
    {
        public Task<IServiceResult> GetState();
    }
}
