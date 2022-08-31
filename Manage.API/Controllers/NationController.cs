using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Nation;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class NationController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public NationController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("nation-insert")]
        public async Task<IActionResult> AllNew([FromBody] NationDTO nation)
        {
            var response = await _serviceWrapper.Nation.AddNew(nation);
            return Ok(response);
        }
        [HttpPost("nation-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Nation.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Nation.GetById(id);
            return Ok(response);
        }
        [HttpPut("nation-update")]
        public async Task<IActionResult> Update([FromBody] UpdateNationDTO update)
        {
            var response = await _serviceWrapper.Nation.Update(update);
            return Ok(response);
        }
        [HttpDelete("nation-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Nation.Delete(ids);
            return Ok(response);
        }
        [HttpPut("nation-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Nation.ChangeStatus(id);
            return Ok(response);
        }
    }
}
