using Ginilytics.Common.Utility.Contract;
using Ginilytics.Service.Data.Model.Contract;
using Ginilytics.Service.Services.Contract;
using Ginilytics.Service.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.Services
{
    [ScopedService]
    public class CommonService //: ICommonService
    {

        private readonly ICommonRepository _commonRepository;
        private readonly IPasswordSecurity _passwordSecurity;
        private readonly IServiceResult _serviceResultSuccessResponse;
        private readonly IServiceResult _serviceResultErrorResponse;
        public CommonService(ICommonRepository commonRepository, IPasswordSecurity passwordSecurity,
            IServiceResult serviceSuccessResult, IServiceResult serviceErrorResult)

        {
            _commonRepository = commonRepository;
            _passwordSecurity = passwordSecurity;
            _serviceResultSuccessResponse = serviceSuccessResult;
            _serviceResultErrorResponse = serviceErrorResult;
            _serviceResultSuccessResponse = GlobalLogic.BuildServiceResult(serviceSuccessResult, true);
            _serviceResultErrorResponse = GlobalLogic.BuildServiceResult(serviceErrorResult, false);
        }
      
    }
}
