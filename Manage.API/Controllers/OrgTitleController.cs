using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.OrgTitle;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgTitleController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public OrgTitleController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("orgTitle-insert")]
        public async Task<IActionResult> AllNew([FromBody] OrgTitleDTO orgTitleDto)
        {
            var response = await _serviceWrapper.OrgTitle.AddNew(orgTitleDto);
            return Ok(response);
        }
        [HttpPost("orgTitle-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.OrgTitle.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.OrgTitle.GetById(id);
            return Ok(response);
        }
        [HttpPut("orgTitle-update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrgTitleDTO update)
        {
            var response = await _serviceWrapper.OrgTitle.Update(update);
            return Ok(response);
        }
        [HttpDelete("orgTitle-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.OrgTitle.Delete(ids);
            return Ok(response);
        }
    }
}
