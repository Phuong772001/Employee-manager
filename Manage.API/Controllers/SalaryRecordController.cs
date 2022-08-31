using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.SalaryRecord;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryRecordController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public SalaryRecordController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("salaryRecord-insert")]
        public async Task<IActionResult> AllNew([FromBody] SalaryRecordDTO salaryRecordDto)
        {
            var response = await _serviceWrapper.SalaryRecord.AddNew(salaryRecordDto);
            return Ok(response);
        }
        [HttpPost("salaryRecord-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.SalaryRecord.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.SalaryRecord.GetById(id);
            return Ok(response);
        }
        [HttpPut("salaryRecord-update")]
        public async Task<IActionResult> Update([FromBody] UpdateSalaryRecordDTO update)
        {
            var response = await _serviceWrapper.SalaryRecord.Update(update);
            return Ok(response);
        }
        [HttpDelete("salaryRecord-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.SalaryRecord.Delete(ids);
            return Ok(response);
        }
    }
}
