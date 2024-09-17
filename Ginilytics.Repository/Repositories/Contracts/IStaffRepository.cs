

using Ginilytics.Model.ViewModels;

namespace Ginilytics.Repository.Repositories.Contracts
{
    public interface IStaffRepository
    {
        Task<List<StaffDetailViewModel>> GetStaff();
        Task<int> InsertStaff(StaffCreateDto staff);
        Task<StaffDetailViewModel> GetStaffById(int id);
        Task<bool> UpdateStaff(StaffUpdateDto staff);
        Task<bool> DeleteStaff(StaffDeleteDto staff);
        Task<StaffDetailViewModel> GetStaffByUserName(string userName);
    }
}
