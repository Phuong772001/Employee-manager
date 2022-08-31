using Manage.Common;
using Manage.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Manage.Model.DTO.Allowance;
using Microsoft.AspNetCore.Authorization;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    public class AllowanceController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public AllowanceController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("allowance-insert")]
        public async Task<IActionResult> AllNew([FromBody]AllowanceDTO allowanceDto)
        {
            var response = await _serviceWrapper.Allowance.AddNew(allowanceDto);
            return Ok(response);
        }
        [HttpPost("allowance-get-all")]
       // [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Allowance.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Allowance.GetById(id);
            return Ok(response);
        }
        [HttpPut("allowance-update")]
        public async Task<IActionResult> Update([FromBody] UpdateAllowanceDTO update)
        {
            var response = await _serviceWrapper.Allowance.Update(update);
            return Ok(response);
        }
        [HttpPut("allowance-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Allowance.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("allowance-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)   
        {
            var response = await _serviceWrapper.Allowance.Delete(ids);
            return Ok(response);
        }
    }
}
