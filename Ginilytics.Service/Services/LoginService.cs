using Microsoft.Extensions.Options;
using Ginilytics.Common.CustomExceptions;
using Ginilytics.Common.Utility;
using Ginilytics.Common.Utility.Contract;
using Ginilytics.Model.DataModels;
using Ginilytics.Model.ViewModels;
using Ginilytics.Service.Data.Model.Common;
using Ginilytics.Service.Services.Contract;
using System.Net;

namespace Ginilytics.Service.Services
{
    [ScopedService]
    public class LoginService : ILoginService
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordSecurity _passwordSecurity;
        private readonly AppSettings _appSettings;
        public LoginService(IPasswordSecurity passwordSecurity,
                            IJwtAuthenticationManager jwtAuthenticationManager, 
                            IOptions<AppSettings> appSettings, 
                            IAuthRepository authRepository)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _authRepository = authRepository;
            _passwordSecurity = passwordSecurity;
            _appSettings = appSettings.Value;

        }
        public async Task<ServiceResult> Login(UserCredentials model)
        {
            try
            {
                var staff = await _authRepository.GetStaffByUserName(model.userName);
                if (staff != null)
                {
                    if (!_passwordSecurity.VerifyPassword(model.password, staff.password))
                        throw new InternalValidationException(GlobalString.InvalidCredentials);
                    else
                        staff.password = String.Empty;
                }
                else
                    throw new InternalValidationException(GlobalString.InvalidCredentials);

                var token = new Token()
                {
                    refreshToken = Guid.NewGuid().ToString(),
                    refreshTokenExpireIn = _appSettings.RefreshTokenExpiryTime,
                    token = _jwtAuthenticationManager.GenerateToken(staff),
                    tokenExpireIn = _appSettings.TokenExpiryTime
                };

                await _authRepository.UpdateStaffTokenAsync(new refreshStaffToken { staffId = staff.id, refreshToken = token.refreshToken, refreshTokenExpiryTime = DateTime.UtcNow.AddMilliseconds(_appSettings.RefreshTokenExpiryTime) });
                return new ServiceResult
                {
                    Message = Global.Success,
                    ResultData = token,
                    Status = true,
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK)
                };

            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Message = Global.Failed,
                    ResultData = GlobalString.InvalidCredentials,
                    Status = false,
                    StatusCode = Convert.ToInt32(HttpStatusCode.ExpectationFailed)
                };
            }

        }
        public async Task<ServiceResult> RefreshToken(RereshTokenModel rereshTokenModel)
        {
            try
            {
                var staff = await _authRepository.GetStaffByRefreshToken(rereshTokenModel);
                if (staff == null)
                {
                    throw new InternalValidationException("Invalid Refresh Token!");
                }
                else
                    staff.password = String.Empty;


                var token = new Token()
                {
                    refreshToken = Guid.NewGuid().ToString(),
                    refreshTokenExpireIn = _appSettings.RefreshTokenExpiryTime,
                    token = _jwtAuthenticationManager.GenerateToken(staff),
                    tokenExpireIn = _appSettings.TokenExpiryTime
                };
                await _authRepository.UpdateStaffTokenAsync(new refreshStaffToken { staffId = staff.id, refreshToken = token.refreshToken, refreshTokenExpiryTime = DateTime.UtcNow.AddMilliseconds(_appSettings.RefreshTokenExpiryTime) });
                return new ServiceResult
                {
                    Message = Global.Success,
                    ResultData = token,
                    Status = true,
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK)

                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Message = Global.Failed,
                    ResultData = ex.Message,
                    Status = true,
                    StatusCode = Convert.ToInt32(HttpStatusCode.ExpectationFailed)
                };
            }
        }
    }
}
