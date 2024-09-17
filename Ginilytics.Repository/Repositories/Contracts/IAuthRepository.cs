using Ginilytics.Model.DataModels;
using Ginilytics.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Repository.Repositories.Contracts
{
    public interface IAuthRepository
    {
        Task<bool> UpdateStaffTokenAsync(refreshStaffToken userToken);
        Task<AuthModel> GetStaffByUserName(string userName);
        Task<AuthModel> GetStaffByRefreshToken(RereshTokenModel rereshTokenModel);
        
    }
}
