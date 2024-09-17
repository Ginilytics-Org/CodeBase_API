using Ginilytics.Model.ViewModels;
using Ginilytics.Service.Data.Model.Contract;

namespace Ginilytics.Service.Services.Contract
{
    public interface IStaffService
    {
        public Task<IServiceResult> GetStaff();
        public Task<IServiceResult> InsertStaff(StaffCreateViewModel staff, int createdBy);
        Task<IServiceResult> GetStaffById(int id);
        Task<IServiceResult> UpdateStaff(StaffUpdateViewModel staff, int modifiedBy);
        Task<IServiceResult> DeleteStaff(int id, int modifiedBy);
        Task<IServiceResult> GetStaffByUserName(string userName);

    }
}
