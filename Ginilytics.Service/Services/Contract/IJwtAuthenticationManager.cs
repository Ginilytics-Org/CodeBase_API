using Ginilytics.Model.DataModels;
namespace Ginilytics.Service
{
    public interface IJwtAuthenticationManager
    {
        string GenerateToken(AuthModel authViewModel);
    }
}
