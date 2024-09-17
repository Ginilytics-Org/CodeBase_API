using Ginilytics.Service.Data.Model.Contract;

namespace Ginilytics.Service.Data.Model.Common
{
    [TransientService]
    public class ServiceResult : IServiceResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic ResultData { get; set; }
        public int StatusCode { get; set; }
    }
}