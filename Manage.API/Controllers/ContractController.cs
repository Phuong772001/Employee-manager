using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Contract;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class ContractController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public ContractController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("contract-insert")]
        public async Task<IActionResult> AllNew([FromBody] ContractDTO contractDto)
        {
            var response = await _serviceWrapper.Contract.AddNew(contractDto);
            return Ok(response);
        }
        [HttpPost("contract-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Contract.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Contract.GetById(id);
            return Ok(response);
        }
        [HttpPut("contract-update")]
        public async Task<IActionResult> Update([FromBody] UpdateContractDTO update)
        {
            var response = await _serviceWrapper.Contract.Update(update);
            return Ok(response);
        }
        [HttpPut("contract-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Contract.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("contract-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Contract.Delete(ids);
            return Ok(response);
        }
    }
}
