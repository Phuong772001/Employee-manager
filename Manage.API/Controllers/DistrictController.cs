using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.District;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public DistrictController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("district-insert")]
        public async Task<IActionResult> AllNew([FromBody] DistrictDTO districtDto)
        {
            var response = await _serviceWrapper.District.AddNew(districtDto);
            return Ok(response);
        }
        [HttpPost("district-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.District.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.District.GetById(id);
            return Ok(response);
        }
        [HttpPut("district-update")]
        public async Task<IActionResult> Update([FromBody] UpdateDistrictDTO update)
        {
            var response = await _serviceWrapper.District.Update(update);
            return Ok(response);
        }
        [HttpPut("district-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.District.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("district-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.District.Delete(ids);
            return Ok(response);
        }
    }
}
