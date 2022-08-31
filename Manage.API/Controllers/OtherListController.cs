using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.OtherList;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherListController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public OtherListController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("otherList-insert")]
        public async Task<IActionResult> AllNew([FromBody] OtherListDTO otherListDto)
        {
            var response = await _serviceWrapper.OtherList.AddNew(otherListDto);
            return Ok(response);
        }
        [HttpPost("otherList-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.OtherList.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.OtherList.GetById(id);
            return Ok(response);
        }
        [HttpPut("otherList-update")]
        public async Task<IActionResult> Update([FromBody] UpdateOtherListDTO update)
        {
            var response = await _serviceWrapper.OtherList.Update(update);
            return Ok(response);
        }
        [HttpDelete("otherList-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.OtherList.Delete(ids);
            return Ok(response);
        }
        [HttpPut("otherlist-update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var response = await _serviceWrapper.OtherList.ChangeStatus(id);
            return Ok(response);
        }
    }
}
