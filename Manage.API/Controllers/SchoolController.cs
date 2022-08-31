using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.School;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public SchoolController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("school-insert")]
        public async Task<IActionResult> AllNew([FromBody] SchoolDTO schoolDto)
        {
            var response = await _serviceWrapper.School.AddNew(schoolDto);
            return Ok(response);
        }
        [HttpPost("school-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.School.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.School.GetById(id);
            return Ok(response);
        }
        [HttpPut("school-update")]
        public async Task<BaseResponse> Update([FromBody] UpdateSchoolDTO update)
        {
            var response = await _serviceWrapper.School.Update(update);
            return response;
        }

        [HttpDelete("school-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.School.Delete(ids);
            return Ok(response);
        }
    }
}
