using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Employee;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employee-insert")]
        public async Task<IActionResult> AllNew([FromBody] EmployeeDTO employeeDto)
        {
            var response = await _serviceWrapper.Employee.AddNew(employeeDto);
            return Ok(response);
        }
        [HttpPost("employee-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Employee.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Employee.GetById(id);
            return Ok(response);
        }
        [HttpPut("employee-update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDTO update)
        {
            var response = await _serviceWrapper.Employee.Update(update);
            return Ok(response);
        }
        [HttpDelete("employee-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Employee.Delete(ids);
            return Ok(response);
        }
    }
}
