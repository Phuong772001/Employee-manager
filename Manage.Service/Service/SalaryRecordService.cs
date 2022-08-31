using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.SalaryRecord;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class SalaryRecordService : ISalaryRecordService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SalaryRecordService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(SalaryRecordDTO salaryRecordDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployee huEmployee = await _repositoryWrapper.Employee.FindById(salaryRecordDto.EmployeeId);
                HuContractAllowance huContractAllowance = await _repositoryWrapper.ContractAllowance.FindById(salaryRecordDto.ContractAllwanceId);
                HuContract huContract = await _repositoryWrapper.Contract.FindById(salaryRecordDto.ContracId);
                HuWelface huWelface = await _repositoryWrapper.Welface.FindById(salaryRecordDto.ContractWelfaceId);
                if (huEmployee == null || huContractAllowance == null || huContract == null || huWelface == null) return Response.NotFoundResponse();
                HuSalaryRecord huSalaryRecord = _mapper.Map<HuSalaryRecord>(salaryRecordDto);
                huSalaryRecord.EmployeeId = huEmployee.Id;
                huSalaryRecord.ContracId = huContract.Id;
                huSalaryRecord.ContractAllwanceId = huContractAllowance.Id;
                huSalaryRecord.ContractWelfaceId = huWelface.Id;
                await _repositoryWrapper.SalaryRecord.Create(huSalaryRecord);
                huSalaryRecord.Code = CreateCode.SalaryCode(huSalaryRecord.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huSalaryRecord);
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
                List<HuSalaryRecord> huSalaryRecords = await _repositoryWrapper.SalaryRecord.GetAll(request);
                List<ListSalaryRecordDTO> listSalaryRecordDtos = _mapper.Map<List<ListSalaryRecordDTO>>(huSalaryRecords);
                return Response.SuccessResponse(listSalaryRecordDtos);
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
                HuSalaryRecord huSalaryRecord = await _repositoryWrapper.SalaryRecord.FindById(id);
                if (huSalaryRecord == null)
                    return Response.NotFoundResponse();
                SalaryRecordDTO salaryRecord = _mapper.Map<SalaryRecordDTO>(huSalaryRecord);
                return Response.SuccessResponse(salaryRecord);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Update(UpdateSalaryRecordDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuSalaryRecord huSalaryRecord = await _repositoryWrapper.SalaryRecord.FindById(update.id);
                if (huSalaryRecord == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, huSalaryRecord);
                await _repositoryWrapper.SalaryRecord.Update(huSalaryRecord);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huSalaryRecord);
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
                    HuSalaryRecord salaryRecord = await _repositoryWrapper.SalaryRecord.FindById(id);
                    if (salaryRecord == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuSalaryRecord salaryRecord = await _repositoryWrapper.SalaryRecord.FindById(id);
                    if (salaryRecord != null)
                        await _repositoryWrapper.SalaryRecord.Delete(salaryRecord);
                }
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
           
        }
    }
}
