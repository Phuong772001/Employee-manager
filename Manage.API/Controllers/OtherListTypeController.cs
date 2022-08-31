using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.OtherListType;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherListTypeController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public OtherListTypeController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("otherListType-insert")]
        public async Task<IActionResult> AllNew([FromBody] OtherListTypeDTO otherListTypeDto)
        {
            var response = await _serviceWrapper.OtherListType.AddNew(otherListTypeDto);
            return Ok(response);
        }
        [HttpPost("otherListType-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.OtherListType.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.OtherListType.GetById(id);
            return Ok(response);
        }
        [HttpPut("otherListType-update")]
        public async Task<IActionResult> Update([FromBody] UpdateOtherListTypeDTO update)
        {
            var response = await _serviceWrapper.OtherListType.Update(update);
            return Ok(response);
        }
      
        [HttpDelete("otherListType-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.OtherListType.Delete(ids);
            return Ok(response);
        }
    }
}
