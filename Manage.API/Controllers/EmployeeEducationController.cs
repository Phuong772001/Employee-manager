using Microsoft.AspNetCore.Mvc;
using Manage.Model.DTO.EmployeeEducation;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEducationController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeEducationController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employeeEducation-insert")]
        public async Task<IActionResult> AllNew([FromBody] EmployeeEducationDTO employeeEducationDto)
        {
            var response = await _serviceWrapper.EmployeeEducation.AddNew(employeeEducationDto);
            return Ok(response);
        }
        //[HttpPost("employeeEducation-get-all")]
        //public async Task<IActionResult> GetAll([FromBody]BaseRequest request)
        //{
        //    var response = await _employeeEducationService.GetAll(request);
        //    return Ok(response);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.EmployeeEducation.GetById(id);
            return Ok(response);
        }
        [HttpPut("employeeEducation-update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeEducationDTO update)
        {
            var response = await _serviceWrapper.EmployeeEducation.Update(update);
            return Ok(response);
        }
        [HttpDelete("employeeEducation-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.EmployeeEducation.Delete(ids);
            return Ok(response);
        }
    }
}
