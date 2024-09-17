using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ginilytics.Api.Startup.Setup.Middlewares;
using Ginilytics.Model.DataModels;
using System.Security.Claims;

namespace Ginilytics.Api.Controllers.Base
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[Action]")]
    public class BaseController : ControllerBase
    {

        internal AuthModel GetUser()
        {
            ClaimsPrincipal user = User;
            var resp = (AuthModel)JsonConvert.DeserializeObject(user.FindFirstValue(ClaimTypes.UserData), typeof(AuthModel));
            return resp;
        }
    }
}