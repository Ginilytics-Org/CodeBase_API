using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ginilytics.Api.Controllers
{
    
    public class CommonController : BaseController
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonService _commonService;

        public CommonController(ILogger<CommonController> logger, ICommonService commonService)
        {
            _logger = logger;
            _commonService = commonService;
        }

        
    }
}
