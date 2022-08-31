using Microsoft.AspNetCore.Mvc;
using Manage.Common;
using Manage.Model.DTO.Title;
using Manage.Service.IService;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class TitleController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public TitleController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }
        [HttpPost("title-insert")]
        public async Task<IActionResult> AllNew([FromBody] TitleDTO titleDto)
        {
            var response = await _serviceWrapper.Title.AddNew(titleDto);
            return Ok(response);
        }
        [HttpPost("title-get-all")]
        public async Task<IActionResult> GetAll([FromBody] BaseRequest request)
        {
            var response = await _serviceWrapper.Title.GetAll(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _serviceWrapper.Title.GetById(id);
            return Ok(response);
        }
        [HttpPut("title-update")]
        public async Task<IActionResult> Update([FromBody] UpdateTitleDTO update)
        {
            var response = await _serviceWrapper.Title.Update(update);
            return Ok(response);
        }
        [HttpDelete("title-delete")]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var response = await _serviceWrapper.Title.Delete(ids);
            return Ok(response);
        }
    }
}
