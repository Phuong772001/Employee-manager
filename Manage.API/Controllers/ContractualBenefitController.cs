using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.ContractualBenefit;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractualBenefitController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public ContractualBenefitController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("contractualBenefit-insert")]
        public async Task<IActionResult> AllNew([FromBody] ContractualBenefitDTO contractualBenefitDto)
        {
            var response = await _serviceWrapper.ContractualBenefit.AddNew(contractualBenefitDto);
            return Ok(response);
        }
        [HttpPost("contractualBenefit-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.ContractualBenefit.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.ContractualBenefit.GetById(id);
            return Ok(response);
        }
        [HttpPut("contractualBenefit-update")]
        public async Task<IActionResult> Update([FromBody] UpdateContractualBenefitDTO update)
        {
            var response = await _serviceWrapper.ContractualBenefit.Update(update);
            return Ok(response);
        }
        [HttpPut("contractBenefit-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.ContractualBenefit.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("contractualBenefit-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.ContractualBenefit.Delete(ids);
            return Ok(response);
        }
    }
}
