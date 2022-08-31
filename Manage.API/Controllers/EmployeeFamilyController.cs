using Microsoft.AspNetCore.Mvc;
using Manage.Model.DTO.EmployeeFamily;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFamilyController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeFamilyController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employeeFamily-insert")]
        public async Task<IActionResult> AllNew([FromBody] EmployeeFamilyDTO employeeFamilyDto)
        {
            var response = await _serviceWrapper.EmployeeFamily.AddNew(employeeFamilyDto);
            return Ok(response);
        }
        //[HttpPost("employeeFamily-get-all")]
        //public async Task<IActionResult> GetAll([FromBody]BaseRequest request)
        //{
        //    var response = await _employeeFamilyService.GetAll(request);
        //    return Ok(response);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.EmployeeFamily.GetById(id);
            return Ok(response);
        }
        [HttpPut("employeeFamily-update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeFamilyDTO update)
        {
            var response = await _serviceWrapper.EmployeeFamily.Update(update);
            return Ok(response);
        }
        [HttpDelete("employeeFamily-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.EmployeeFamily.Delete(ids);
            return Ok(response);
        }
    }
}
