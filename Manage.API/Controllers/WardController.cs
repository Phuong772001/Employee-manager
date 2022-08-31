using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Ward;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public WardController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("ward-insert")]
        public async Task<IActionResult> AllNew([FromBody] WardDTO wardDto)
        {
            var response = await _serviceWrapper.Ward.AddNew(wardDto);
            return Ok(response);
        }
        [HttpPost("ward-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Ward.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Ward.GetById(id);
            return Ok(response);
        }
        [HttpPut("ward-update")]
        public async Task<IActionResult> Update([FromBody] UpdateWardDTO update)
        {
            var response = await _serviceWrapper.Ward.Update(update);
            return Ok(response);
        }
        [HttpPut("ward-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Ward.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("ward-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Ward.Delete(ids);
            return Ok(response);
        }
    }
}
