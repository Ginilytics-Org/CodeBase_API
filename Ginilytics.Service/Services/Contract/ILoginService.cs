using Ginilytics.Model.ViewModels;
using Ginilytics.Service.Data.Model.Common;

namespace Ginilytics.Service.Services.Contract
{
    public interface ILoginService
    {
        Task<ServiceResult> Login(UserCredentials model);
        Task<ServiceResult> RefreshToken(RereshTokenModel refreshCredentials);
    }
}
