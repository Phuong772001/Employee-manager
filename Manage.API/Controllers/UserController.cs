using Manage.Common;
using Manage.Model.DTO.User;
using Manage.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Manage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;

        public UserController(IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO user)
        {
            BaseResponse res = await _serviceWrapper.User.Register(user);
            return Ok(res);
        }
        [HttpPost("get-all-users")]
        public async Task<IActionResult> GetAllUsers([FromBody] BaseRequest baseRequest)
        {
            BaseResponse res = await _serviceWrapper.User.GetAllUsers(baseRequest);
            return Ok(res);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            BaseResponse res = await _serviceWrapper.User.Login(user);
            return Ok(res);
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> Delete([FromBody] List<int> id)
        {
            BaseResponse res = await _serviceWrapper.User.DeleteUsers(id);
            return Ok(res);
        }
        [HttpPut("user-update-status")]
        // [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            BaseResponse res = await _serviceWrapper.User.ChangeStatus(id);
            return Ok(res);
        }

        [HttpPost("renew-token")]
        public async Task<IActionResult> RenewToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            BaseResponse res = await _serviceWrapper.User.RenewToken(refreshTokenDTO);
            return Ok(res);
        }
    }
}
