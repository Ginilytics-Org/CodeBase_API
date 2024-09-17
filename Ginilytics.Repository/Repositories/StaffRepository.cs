using Dapper;
using Ginilytics.Common.ServiceInstallers.Attributes;
using Ginilytics.Model.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace Ginilytics.Repository.Repositories
{
    [SingletonService]
    public class StaffRepository : IStaffRepository
    {
        private readonly IDbProvider _dbProvider;

        public StaffRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task<bool> DeleteStaff(StaffDeleteDto staff)
        {
            await _dbProvider.ExecuteAsync("[staff].[sp_deleteStaff]", staff, CommandType.StoredProcedure);
            return true;
        }

        public async Task<List<StaffDetailViewModel>> GetStaff()
        {
            var result = await _dbProvider.ExecuteQueryAsync<StaffDetailViewModel>("[staff].[sp_getStaffList]", CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<StaffDetailViewModel> GetStaffById(int id)
        {
            var param = new { id };
            var result = await _dbProvider.ExecuteQueryAsync<StaffDetailViewModel>("[staff].[sp_getStaffById]", param, CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<StaffDetailViewModel> GetStaffByUserName(string userName)
        {
            var param = new { userName };
            var result = await _dbProvider.ExecuteQueryAsync<StaffDetailViewModel>("[staff].[sp_getStaffByUserName]", param, CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> InsertStaff(StaffCreateDto staff)
        {
            var createdId = await _dbProvider.ExecuteScalarAsync<int>("[staff].[sp_insertStaff]", staff, CommandType.StoredProcedure);
            return createdId;
        }

        public async Task<bool> UpdateStaff(StaffUpdateDto staff)
        {
            await _dbProvider.ExecuteAsync("[staff].[sp_updateStaff]", staff, CommandType.StoredProcedure);
            return true;
        }
    }
}
