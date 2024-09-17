using Mapster;
using Ginilytics.Common.CustomExceptions;
using Ginilytics.Common.Utility.Contract;
using Ginilytics.Model.ViewModels;
using Ginilytics.Service.Data.Model.Contract;
using Ginilytics.Service.Services.Contract;
using Ginilytics.Service.Setup;
using Microsoft.Extensions.Logging;

namespace Ginilytics.Service.Services
{
    [ScopedService]
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IPasswordSecurity _passwordSecurity;
        private readonly IServiceResult _serviceResultSuccessResponse;
        private readonly IServiceResult _serviceResultErrorResponse;
        private readonly ILogger<StaffService> _logger;
        private readonly Guid _guid;
        public StaffService(IStaffRepository staffRepository, IPasswordSecurity passwordSecurity,
            IServiceResult serviceSuccessResult, IServiceResult serviceErrorResult,
            ILogger<StaffService> logger)

        {
            _staffRepository = staffRepository;
            _passwordSecurity = passwordSecurity;
            _serviceResultSuccessResponse = serviceSuccessResult;
            _serviceResultErrorResponse = serviceErrorResult;
            _serviceResultSuccessResponse = GlobalLogic.BuildServiceResult(serviceSuccessResult, true);
            _serviceResultErrorResponse = GlobalLogic.BuildServiceResult(serviceErrorResult, false);
            _logger = logger;
            _guid = Guid.NewGuid();
        }

        public async Task<IServiceResult> DeleteStaff(int id, int modifiedBy)
        {
            try
            {
                var destObject = new StaffDeleteDto()
                {
                    id = id,
                    modifiedBy = modifiedBy,
                    utcDateDeleted = DateTime.UtcNow
                };
                var result = await _staffRepository.DeleteStaff(destObject);

                if (result)
                {
                    _serviceResultSuccessResponse.ResultData = result;
                    return _serviceResultSuccessResponse;
                }
                else
                {
                    return _serviceResultErrorResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occred while getting all delete Staff. ErrorId = " + _guid); ;
                _serviceResultErrorResponse.Message = ex.Message;
                return _serviceResultErrorResponse;
            }
        }

        public async Task<IServiceResult> GetStaff()
        {
            try
            {
                var result = await _staffRepository.GetStaff();
                _serviceResultSuccessResponse.ResultData = result;
                return _serviceResultSuccessResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occred while getting all delete GetStaff. ErrorId = " + _guid); ;
                _serviceResultErrorResponse.Message = ex.Message;
                return _serviceResultErrorResponse;
            }
        }

        public async Task<IServiceResult> GetStaffById(int id)
        {
            try
            {
                var result = await _staffRepository.GetStaffById(id);
                _serviceResultSuccessResponse.ResultData = result;
                return _serviceResultSuccessResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occred while getting GetStaffById. ErrorId = " + _guid);
                _serviceResultErrorResponse.Message = ex.Message;
                return _serviceResultErrorResponse;
            }
        }

        public async Task<IServiceResult> GetStaffByUserName(string userName)
        {
            try
            {
                var result = await _staffRepository.GetStaffByUserName(userName);
                _serviceResultSuccessResponse.ResultData = result;
                return _serviceResultSuccessResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occred while getting GetStaffByUserName. ErrorId = " + _guid);
                _serviceResultErrorResponse.Message = ex.Message;
                return _serviceResultErrorResponse;
            }
        }

        public async Task<IServiceResult> InsertStaff(StaffCreateViewModel staff, int createdBy)
        {
            try
            {
                var userName = await _staffRepository.GetStaffByUserName(staff.userName);
                if (userName == null)
                {
                    var destObject = staff.Adapt(new StaffCreateDto());
                    destObject.utcDateCreated = DateTime.UtcNow;
                    destObject.createdBy = createdBy;
                    destObject.password = _passwordSecurity.CreateHash(staff.password);
                    destObject.isActive = true;
                    var id = await _staffRepository.InsertStaff(destObject);
                    if (id > 0)
                    {
                        _serviceResultSuccessResponse.ResultData = new { staffId = id };
                        return _serviceResultSuccessResponse;
                    }
                    else
                    {
                        return _serviceResultErrorResponse;
                    }
                }
                else
                {
                    throw new InternalValidationException("User with the given userName already exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occred while getting InsertStaff. ErrorId = " + _guid);
                _serviceResultErrorResponse.Message = ex.Message;
                return _serviceResultErrorResponse;
            }
        }

        public async Task<IServiceResult> UpdateStaff(StaffUpdateViewModel staff, int modifiedBy)
        {
            try
            {
                var destObject = staff.Adapt(new StaffUpdateDto());
                destObject.utcDateModified = DateTime.UtcNow;
                destObject.modifiedBy = modifiedBy;
                var result = await _staffRepository.UpdateStaff(destObject);
                if (result)
                {
                    _serviceResultSuccessResponse.ResultData = result;
                    return _serviceResultSuccessResponse;
                }
                else
                {
                    return _serviceResultErrorResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occred while getting UpdateStaff. ErrorId = " + _guid);
                _serviceResultErrorResponse.Message = ex.Message;
                return _serviceResultErrorResponse;
            }
        }
    }
}
