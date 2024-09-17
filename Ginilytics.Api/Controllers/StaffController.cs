using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ginilytics.Model.ViewModels;

namespace Ginilytics.Api.Controllers
{
    public class StaffController : BaseController
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IStaffService _staffService;
        

        public StaffController(ILogger<StaffController> logger, IStaffService staffService)
        {
            _logger = logger;
            _staffService = staffService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetStaff()
        {
            
            return Ok(await _staffService.GetStaff());
        }
        
        [HttpPost]
        public async Task<IActionResult> InsertStaff(StaffCreateViewModel staff)
        {
            
            if (staff != null && ModelState.IsValid)
            {
                var createdby = GetUser().id;
                var result = await _staffService.InsertStaff(staff, createdby);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            if (id >= 0)
            {
                return Ok(await _staffService. GetStaffById(id));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaff([FromBody] StaffUpdateViewModel staff)
        {
            if (staff != null && ModelState.IsValid)
            {
                var modifieddby = GetUser().id;
                var result = await _staffService.UpdateStaff(staff, modifieddby);

                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (id > 0)
            {
                var modifiedBy = GetUser().id;
                var result = await _staffService.DeleteStaff(id, modifiedBy);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

    }

}
