using Microsoft.AspNetCore.Mvc;
using Manage.Model.DTO.EmployeeCv;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCvController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public EmployeeCvController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("employeeCv-insert")]
        public async Task<IActionResult> AllNew([FromBody] EmployeeCvDTO employeeCvDto)
        {
            var response = await _serviceWrapper.EmployeeCv.AddNew(employeeCvDto);
            return Ok(response);
        }
        //[HttpPost("employeeCv-get-all")]
        //public async Task<IActionResult> GetAll([FromBody]BaseRequest request)
        //{
        //    var response = await _employeeCvService.GetAll(request);
        //    return Ok(response);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.EmployeeCv.GetById(id);
            return Ok(response);
        }
        [HttpPut("employeeCv-update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCvDTO update)
        {
            var response = await _serviceWrapper.EmployeeCv.Update(update);
            return Ok(response);
        }
        [HttpDelete("employeeCv-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.EmployeeCv.Delete(ids);
            return Ok(response);
        }
    }
}
