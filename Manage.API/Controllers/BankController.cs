using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Bank;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class BankController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public BankController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("bank-insert")]
        public async Task<IActionResult> AllNew([FromBody] BankDTO bankDto)
        {
            var response = await _serviceWrapper.Bank.AddNew(bankDto);
            return Ok(response);
        }
        [HttpPost("bank-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Bank.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Bank.GetById(id);
            return Ok(response);
        }
        [HttpPut("bank-update")]
        public async Task<IActionResult> Update([FromBody] UpdateBankDTO update)
        {
            var response = await _serviceWrapper.Bank.Update(update);
            return Ok(response);
        }
        [HttpPut("bank-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.Bank.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("bank-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Bank.Delete(ids);
            return Ok(response);
        }
    }
}
