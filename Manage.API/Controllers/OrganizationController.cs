using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Organization;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public OrganizationController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("organization-insert")]
        public async Task<IActionResult> AllNew([FromBody] OrganizationDTO organizationDto)
        {
            var response = await _serviceWrapper.Organization.AddNew(organizationDto);
            return Ok(response);
        }
        [HttpPost("organization-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Organization.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Organization.GetById(id);
            return Ok(response);
        }
        [HttpPut("organization-update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrganizationDTO update)
        {
            var response = await _serviceWrapper.Organization.Update(update);
            return Ok(response);
        }
        [HttpPut("organization-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Organization.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("organization-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Organization.Delete(ids);
            return Ok(response);
        }
    }
}
