using AutoMapper;
using Manage.Common;
using Manage.Service.IService;
using Manage.Model.Context;
using Manage.Model.DTO.Allowance;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Manage.Model.DTO.User;

namespace Manage.Service.Service
{
    public class AllowanceService : IAllowanceService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AllowanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(AllowanceDTO allowance)
        {

            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                if (isHasToken == false) return Response.AuthHeaderResponse();
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuAllowance huAllowance = await _repositoryWrapper.Allowance.FindByName(allowance.Name);
                if (huAllowance != null) return Response.DuplicateDataResponse("allwance already exist");
                huAllowance = _mapper.Map<HuAllowance>(allowance);
                await _repositoryWrapper.Allowance.Create(huAllowance);
                huAllowance.Code = CreateCode.AllowanceCode(huAllowance.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huAllowance);
                await _context.SaveChangesAsync();
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
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                if (isHasToken == false) return Response.AuthHeaderResponse();
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                if (request.pageNum < 1 || request.pageSize < 1)
                    return Response.NotFoundResponse();
                if (request.pageNum > request.pageSize)
                    return Response.NotFoundResponse();
                List<HuAllowance> huAllowances = await _repositoryWrapper.Allowance.GetAll(request);
                List<ListAllowanceDTO> listAllowance = _mapper.Map<List<ListAllowanceDTO>>(huAllowances);
                return Response.SuccessResponse(listAllowance);
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
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                if (isHasToken == false) return Response.AuthHeaderResponse();

                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuAllowance huAllowance = await _repositoryWrapper.Allowance.FindById(id);
                if (huAllowance == null)
                    return Response.NotFoundResponse();
                AllowanceDTO allowance = _mapper.Map<AllowanceDTO>(huAllowance);
                return Response.SuccessResponse(allowance);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }

        }

        public async Task<BaseResponse> Update(UpdateAllowanceDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse();

                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(update.id);
                if (allowance == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, allowance);
                await _repositoryWrapper.Allowance.Update(allowance);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, allowance);
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
                    HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(id);
                    if (allowance == null)
                    {
                        return Response.NotFoundResponse($"allwance with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(id);
                    if (allowance != null)
                        await _repositoryWrapper.Allowance.Delete(allowance);
                }
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
                HuAllowance allowance = await _repositoryWrapper.Allowance.FindById(id);
                if (allowance == null)
                    return Response.NotFoundResponse();
                allowance.Activeflg = Tools.ChangeStatus(allowance.Activeflg);
                await _repositoryWrapper.Allowance.Update(allowance);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, allowance);
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
