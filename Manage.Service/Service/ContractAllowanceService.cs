using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.ContractAllowance;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ContractAllowanceService : IContractAllowanceService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContractAllowanceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(ContractAllowanceDTO contractAllowanceDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuContract huContract = await _repositoryWrapper.Contract.FindByName(contractAllowanceDto.Contract);
                if (huContract == null) return Response.NotFoundResponse("contract not exist");
                HuAllowance huAllowance = await _repositoryWrapper.Allowance.FindByName(contractAllowanceDto.Allwance);
                if (huAllowance == null) return Response.NotFoundResponse("allowance not exist");
                if (await _repositoryWrapper.ContractAllowance.FindData(huContract.Id, huAllowance.Id) != null)
                    return Response.DuplicateDataResponse("data already exist");
                HuContractAllowance huContractAllowance = new HuContractAllowance
                {
                    AllwanceId = huAllowance.Id,
                    ContractId = huContract.Id,
                    Money = contractAllowanceDto.Money,
                };
                await _repositoryWrapper.ContractAllowance.Create(huContractAllowance);
                huContractAllowance.Code = CreateCode.ContractAllowanceCode(huContractAllowance.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huContractAllowance);
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
                List<HuContractAllowance> huContractAllowances = await _repositoryWrapper.ContractAllowance.GetAll(request);
                List<ListContractAllowanceDTO> listContractAllowances = _mapper.Map<List<ListContractAllowanceDTO>>(huContractAllowances);
                return Response.SuccessResponse(listContractAllowances);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
           
        }

        public async  Task<BaseResponse> GetById(int id)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(id);
                if (huContractAllowance == null)
                    return Response.NotFoundResponse();
                HuAllowance huAllowance = await _repositoryWrapper.Allowance.FindById(huContractAllowance.AllwanceId);
                HuContract huContract = await _repositoryWrapper.Contract.FindById(huContractAllowance.ContractId);
                ContractAllowanceDTO contractAllowanceDTO = _mapper.Map<ContractAllowanceDTO>(huContractAllowance);
                contractAllowanceDTO.Allwance = huAllowance.Name;
                contractAllowanceDTO.Contract = huContract.Name;
                return Response.SuccessResponse(contractAllowanceDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
           
        }

        public async Task<BaseResponse> Update(UpdateContractAllowanceDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(update.id);
                if (huContractAllowance == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, huContractAllowance);
                await _repositoryWrapper.ContractAllowance.Update(huContractAllowance);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huContractAllowance);
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
                    HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(id);
                    if (huContractAllowance == null)
                    {
                        return Response.NotFoundResponse($"contractallwance with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(id);
                    if (huContractAllowance != null)
                        await _repositoryWrapper.ContractAllowance.Delete(huContractAllowance);
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
                HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(id);
                if (huContractAllowance == null)
                    return Response.NotFoundResponse();
                huContractAllowance.Activeflg = Tools.ChangeStatus(huContractAllowance.Activeflg);
                await _repositoryWrapper.ContractAllowance.Update(huContractAllowance);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huContractAllowance);
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
