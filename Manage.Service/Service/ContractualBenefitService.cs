using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.ContractualBenefit;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ContractualBenefitService : IContractualBenefitService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContractualBenefitService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(ContractualBenefitDTO contractualBenefitDto)
        {
                try
                {
                    bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                    TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                    TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                    BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                    if (tokenResponse != null)
                        return tokenResponse;
                    HuContract huContract = await _repositoryWrapper.Contract.FindByName(contractualBenefitDto.Contract);
                    if (huContract == null) return Response.NotFoundResponse("contract not exist");
                    HuWelface huWelface = await _repositoryWrapper.Welface.FindByName(contractualBenefitDto.Welface);
                    if (huWelface == null) return Response.NotFoundResponse("welface not exist");
                if (await _repositoryWrapper.ContractWelface.FindData(huContract.Id, huWelface.Id) != null)
                    return Response.DuplicateDataResponse("data already exist");
                HuContractWelface huContractWelface = new HuContractWelface
                    {
                        WelfaceId = huWelface.Id,
                        ContractId = huContract.Id,
                        Money = contractualBenefitDto.Money,
                    };
                    await _repositoryWrapper.ContractWelface.Create(huContractWelface);
                huContractWelface.Code = CreateCode.ContractWelfaceCode(huContractWelface.Id);
                    UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                    _mapper.Map(userInfoCreate, huContractWelface);
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
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                if (request.pageNum < 1 || request.pageSize < 1)
                    return Response.NotFoundResponse();
                if (request.pageNum > request.pageSize)
                    return Response.NotFoundResponse();
                List<HuContractWelface> huContractWelfaces = await _repositoryWrapper.ContractWelface.GetAll(request);
                List<ListContractualBenefitDTO> listContractualBenefitDTOs = _mapper.Map<List<ListContractualBenefitDTO>>(huContractWelfaces);
                return Response.SuccessResponse(listContractualBenefitDTOs);
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
                HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(id);
                if (huContractWelface == null)
                    return Response.NotFoundResponse();
                HuContract huContract = await _repositoryWrapper.Contract.FindById(huContractWelface.ContractId);
                HuWelface huWelface = await _repositoryWrapper.Welface.FindById(huContractWelface.WelfaceId);
                ContractualBenefitDTO contractualBenefitDTO = _mapper.Map<ContractualBenefitDTO>(huContractWelface);
                contractualBenefitDTO.Welface = huWelface.Name;
                contractualBenefitDTO.Contract = huContract.Name;
                return Response.SuccessResponse(contractualBenefitDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> Update(UpdateContractualBenefitDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(update.id);
                if (huContractWelface == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, huContractWelface);
                await _repositoryWrapper.ContractWelface.Update(huContractWelface);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huContractWelface);
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
                    HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(id);
                    if (huContractWelface == null)
                    {
                        return Response.NotFoundResponse($"Contractwelface with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(id);
                    if (huContractWelface != null)
                        await _repositoryWrapper.ContractWelface.Delete(huContractWelface);
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
                HuContractWelface huContractWelface = await _repositoryWrapper.ContractWelface.FindById(id);
                if (huContractWelface == null)
                    return Response.NotFoundResponse();
                huContractWelface.Activeflg = Tools.ChangeStatus(huContractWelface.Activeflg);
                await _repositoryWrapper.ContractWelface.Update(huContractWelface);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huContractWelface);
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
