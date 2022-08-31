using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Manage.Service.Service
{
    public class UserService :  IUserService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> ChangeStatus(int id)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                SeUser existUser = await _repositoryWrapper.User.FindById(id);
                if (existUser == null)
                    return Response.NotFoundResponse();
                existUser.Activeflg = Tools.ChangeStatus(existUser.Activeflg);
                await _repositoryWrapper.User.Update(existUser);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, existUser);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> DeleteUsers(List<int> ids)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                foreach (int id in ids)
                {
                    SeUser existUser = await _repositoryWrapper.User.FindById(id);
                    if (existUser != null)
                        await _repositoryWrapper.User.Delete(existUser);
                }
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> FindUserById(int id)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                SeUser existUser = await _repositoryWrapper.User.FindById(id);
                if (existUser == null)
                    return Response.NotFoundResponse();
                return Response.SuccessResponse(existUser);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
           
        }

        public async Task<BaseResponse> GetAllUsers(BaseRequest request)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                List<SeUser> allUsers = await _repositoryWrapper.User.FindAllData(request);
                List<ListUserDTO> listUser = _mapper.Map<List<ListUserDTO>>(allUsers);
                return Response.SuccessResponse(listUser);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Login(LoginDTO user)
        {
            try
            {
                string encodePass = Tools.EncodingUTF8(user.password);
                string description = await _repositoryWrapper.User.CheckUserLogin(user.username, encodePass);
                if (description == null)
                {
                    SeToken seToken = new SeToken();
                    SeUser loginUser = await _repositoryWrapper.User.FindByUsername(user.username);
                    TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                    seToken = tokenConfiguration.GenerateTokens(loginUser);
                    loginUser.access_token = seToken.access_token;
                    loginUser.refresh_token = seToken.refresh_token;
                    loginUser.expired_time = DateTime.UtcNow.AddDays(7);
                    await _repositoryWrapper.User.Update(loginUser);
                    await _context.SaveChangesAsync();
                    return Response.SuccessResponse(seToken);
                }
                return Response.BadLoginResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        
        public async Task<BaseResponse> Register(UserDTO reUser)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                BaseResponse checkPassword = Tools.CheckPassword(reUser.password);
                if (checkPassword != null)
                    return checkPassword;
                SeUser user = await _repositoryWrapper.User.FindByUsername(reUser.username);
                if (user != null)
                    return Response.DuplicateDataResponse("username already exist");
                reUser.password = Tools.EncodingUTF8(reUser.password);
                SeUser newUser = _mapper.Map<SeUser>(reUser);
                await _repositoryWrapper.User.Create(newUser);
                newUser.Code = CreateCode.UserCode(newUser.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, newUser);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> RenewToken(RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                bool isTrue = await _repositoryWrapper.User.CheckRefreshToken(refreshTokenDTO.username, refreshTokenDTO.refresh_token);
                if (isTrue == false) return Response.TokenInvalidResponse();
                SeUser loginUser = await _repositoryWrapper.User.FindByUsername(refreshTokenDTO.username);
                loginUser.access_token = tokenConfiguration.GeneratetokenConfiguration(loginUser);
                await _repositoryWrapper.User.Update(loginUser);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, loginUser);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse(loginUser.access_token);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }
    }
}
