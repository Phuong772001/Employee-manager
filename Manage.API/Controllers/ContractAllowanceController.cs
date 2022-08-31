using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.ContractAllowance;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractAllowanceController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public ContractAllowanceController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("contractAllowance-insert")]
        public async Task<IActionResult> AllNew([FromBody] ContractAllowanceDTO contractAllowanceDto)
        {
            var response = await _serviceWrapper.ContractAllowance.AddNew(contractAllowanceDto);
            return Ok(response);
        }
        [HttpPost("contractAllowance-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.ContractAllowance.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.ContractAllowance.GetById(id);
            return Ok(response);
        }
        [HttpPut("contractAllowance-update")]
        public async Task<IActionResult> Update([FromBody] UpdateContractAllowanceDTO update)
        {
            var response = await _serviceWrapper.ContractAllowance.Update(update);
            return Ok(response);
        }
        [HttpPut("contractAllowance-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.ContractAllowance.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("contractAllowance-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.ContractAllowance.Delete(ids);
            return Ok(response);
        }
    }
}
