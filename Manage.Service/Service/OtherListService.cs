using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.OtherList;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class OtherListService: IOtherListService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OtherListService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> AddNew(OtherListDTO otherListDTO)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                
                if (tokenResponse != null)
                    return tokenResponse;
                OtherList otherList = await _repositoryWrapper.OtherList.FindByName(otherListDTO.Name);
                if (otherList != null) return Response.DuplicateDataResponse("list already exist");
                OtherListType otherListType = await _repositoryWrapper.OtherListType.FindByName(otherListDTO.TypeName);
                if (otherListType == null) return Response.DuplicateDataResponse("type not exist");
                otherList = _mapper.Map<OtherList>(otherListDTO);
                otherList.TypeId = otherListType.Id;
                await _repositoryWrapper.OtherList.Create(otherList);
                otherList.Code = CreateCode.OtherListCode(otherList.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, otherList);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Delete(List<int> ids)
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
                    OtherList otherList = await _repositoryWrapper.OtherList.FindById(id);
                    if (otherList == null)
                    {
                        return Response.NotFoundResponse($"list with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    OtherList otherList = await _repositoryWrapper.OtherList.FindById(id);
                    if (otherList != null)
                        await _repositoryWrapper.OtherList.Delete(otherList);
                }
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> GetAll(BaseRequest request)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                List<OtherList> otherLists = await _repositoryWrapper.OtherList.GetAll(request);
                List<ListOtherListDTO> listOtherListDTOs = _mapper.Map<List<ListOtherListDTO>>(otherLists);
                return Response.SuccessResponse(listOtherListDTOs);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> GetById(int id)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                OtherList otherList = await _repositoryWrapper.OtherList.FindById(id);
                if (otherList == null) return Response.NotFoundResponse();
                OtherListDTO otherListDTO = _mapper.Map<OtherListDTO>(otherList);
                return Response.SuccessResponse(otherListDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> Update(UpdateOtherListDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                OtherList otherList = await _repositoryWrapper.OtherList.FindById(update.Id);
                if (otherList == null) return Response.DataNullResponse();
                _mapper.Map(update.updateData, otherList);
                await _repositoryWrapper.OtherList.Update(otherList);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, otherList);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
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
                OtherList otherList = await _repositoryWrapper.OtherList.FindById(id);
                if (otherList == null)
                    return Response.NotFoundResponse();
                otherList.Activeflg = Tools.ChangeStatus(otherList.Activeflg);
                await _repositoryWrapper.OtherList.Update(otherList);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, otherList);
                await _context.SaveChangesAsync();
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }
    }
}
