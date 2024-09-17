using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Service.Data.Model.Contract
{
    public interface IServiceResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic ResultData { get; set; }
        public int StatusCode { get; set; }
    }
}
