using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.BankBranch;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class BankBranchService : IBankBranchService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BankBranchService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(BankBranchDTO bankBranch)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuBank huBank = await _repositoryWrapper.Bank.FindByName(bankBranch.BankName);
                if (huBank == null) return Response.NotFoundResponse("bank not exsit");
                HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindAddress(bankBranch.Address);
                if (huBankBranch != null) return Response.DuplicateDataResponse("address already exist");
                huBankBranch = _mapper.Map<HuBankBranch>(bankBranch);
                huBankBranch.BankId = huBank.Id;
                await _repositoryWrapper.BankBranch.Create(huBankBranch);
                huBankBranch.Code = CreateCode.BankBranchCode(huBankBranch.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huBankBranch);
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
                List<HuBankBranch> huBankBranches = await _repositoryWrapper.BankBranch.GetAll(request);
                List<ListBankBranch> listBankBranches = _mapper.Map<List<ListBankBranch>>(huBankBranches);
                listBankBranches = await _repositoryWrapper.Bank.FindAllBankById(listBankBranches);
                List<ListBankBranchDTO> listBankBranchDTOs = _mapper.Map<List<ListBankBranchDTO>>(listBankBranches);
                return Response.SuccessResponse(listBankBranchDTOs);
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
                HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(id);
                HuBank huBank = await _repositoryWrapper.Bank.FindById(huBankBranch.BankId);
                if (huBankBranch == null)
                    return Response.NotFoundResponse();
                BankBranchDTO bankBranch = _mapper.Map<BankBranchDTO>(huBankBranch);
                bankBranch.BankName = huBank.Name;
                return Response.SuccessResponse(bankBranch);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Update(UpdateBankBranchDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(update.Id);
                if (huBankBranch == null)
                    return Response.NotFoundResponse();
                HuBank huBank = await _repositoryWrapper.Bank.FindByName(update.updateData.BankName);
                if (huBank == null) return Response.NotFoundResponse("bank not exist");
                _mapper.Map(update.updateData, huBankBranch);
                huBankBranch.BankId = huBank.Id;
                await _repositoryWrapper.BankBranch.Update(huBankBranch);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huBankBranch);
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
                    HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(id);
                    if (huBankBranch == null)
                    {
                        return Response.NotFoundResponse($"bankbranch with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(id);
                    if (huBankBranch != null)
                        await _repositoryWrapper.BankBranch.Delete(huBankBranch);
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
                HuBankBranch huBankBranch = await _repositoryWrapper.BankBranch.FindById(id);
                if (huBankBranch == null)
                    return Response.NotFoundResponse();
                huBankBranch.Activeflg = Tools.ChangeStatus(huBankBranch.Activeflg);
                await _repositoryWrapper.BankBranch.Update(huBankBranch);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huBankBranch);
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
