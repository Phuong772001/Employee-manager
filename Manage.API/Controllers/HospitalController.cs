using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Hospital;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class HospitalController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public HospitalController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("hospital-insert")]
        public async Task<IActionResult> AllNew([FromBody] HospitalDTO hospital)
        {
            var response = await _serviceWrapper.Hospital.AddNew(hospital);
            return Ok(response);
        }
        [HttpPost("hospital-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Hospital.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Hospital.GetById(id);
            return Ok(response);
        }
        [HttpPut("hospital-update")]
        public async Task<IActionResult> Update([FromBody] UpdateHospitalDTO update)
        {
            var response = await _serviceWrapper.Hospital.Update(update);
            return Ok(response);
        }
        [HttpDelete("hospital-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Hospital.Delete(ids);
            return Ok(response);
        }
    }
}
