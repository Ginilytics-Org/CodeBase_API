using Ginilytics.Model.DataModels;
using Ginilytics.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginilytics.Repository.Repositories
{
    [SingletonService]
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbProvider _dbProvider;
        public AuthRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }
        public async Task<bool> UpdateStaffTokenAsync(refreshStaffToken userToken)
        {
            await _dbProvider.ExecuteScalarAsync<int>("[staff].[sp_updateStaffToken]", userToken);
            return true;
        }
        public async Task<AuthModel> GetStaffByUserName(string userName)
        {
            var result = await _dbProvider.ExecuteQueryAsync<AuthModel>("[staff].[sp_getStaffByUserName]", new { userName = userName });
            return result.FirstOrDefault();
        }
        public async Task<AuthModel> GetStaffByRefreshToken(RereshTokenModel rereshTokenModel)
        {
            var result = await _dbProvider.ExecuteQueryAsync<AuthModel>("[staff].[sp_GetStaffByRefreshToken]", rereshTokenModel);
            return result.FirstOrDefault();
        }
    }
}
