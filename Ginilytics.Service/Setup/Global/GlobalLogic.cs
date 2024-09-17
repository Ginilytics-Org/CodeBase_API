using Ginilytics.Service.Data.Model.Contract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ginilytics.Service.Setup
{
    public static class GlobalLogic
    {
        public static IServiceResult BuildServiceResult(IServiceResult _serviceResultResponse, bool status)
        {
            _serviceResultResponse.Status = status == true ? status : false;
            _serviceResultResponse.Message = status == true ? Global.Success : Global.Failed;
            _serviceResultResponse.StatusCode = status == true ? Convert.ToInt32(HttpStatusCode.OK) : Convert.ToInt32(HttpStatusCode.NotImplemented);
            return _serviceResultResponse;
        }
    }
}
