using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Welface;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelfaceController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public WelfaceController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("welfare-insert")]
        public async Task<IActionResult> AllNew([FromBody] WelfaceDTO welfareDto)
        {
            var response = await _serviceWrapper.Welface.AddNew(welfareDto);
            return Ok(response);
        }
        [HttpPost("welfare-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Welface.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Welface.GetById(id);
            return Ok(response);
        }
        [HttpPut("welfare-update")]
        public async Task<IActionResult> Update([FromBody] UpdateWelfaceDTO update)
        {
            var response = await _serviceWrapper.Welface.Update(update);
            return Ok(response);
        }
        [HttpPut("welface-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Welface.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("welfare-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Welface.Delete(ids);
            return Ok(response);
        }
    }
}
