using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ginilytics.Model.ViewModels;

namespace Ginilytics.Api.Controllers
{
    public class AuthController : BaseController
    {

        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserCredentials model)
        {
            if (ModelState.IsValid)
            {
                var token = await _loginService.Login(model);
                return Ok(token);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RereshTokenModel rereshTokenModel)
        {
            if (ModelState.IsValid)
            {
                var token = await _loginService.RefreshToken(rereshTokenModel);

                return Ok(token);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}