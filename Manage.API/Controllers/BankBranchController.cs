using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.BankBranch;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBranchController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public BankBranchController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("bankBranch-insert")]
        public async Task<IActionResult> AllNew([FromBody] BankBranchDTO bankBranchDto)
        {
            var response = await _serviceWrapper.BankBranch.AddNew(bankBranchDto);
            return Ok(response);
        }
        [HttpPost("bankBranch-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.BankBranch.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.BankBranch.GetById(id);
            return Ok(response);
        }
        [HttpPut("bankBranch-update")]
        public async Task<IActionResult> Update([FromBody] UpdateBankBranchDTO update)
        {
            var response = await _serviceWrapper.BankBranch.Update(update);
            return Ok(response);
        }
        [HttpPut("bankBranch-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.BankBranch.ChangeStatus(id);
            return Ok(response);
        }
        [HttpDelete("bankBranch-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.BankBranch.Delete(ids);
            return Ok(response);
        }
    }
}
