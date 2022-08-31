using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Employee;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repositoryWrapper;
        private DatabaseContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(EmployeeDTO employeeDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse();
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployee huEmployee = _mapper.Map<HuEmployee>(employeeDto);
                await _repositoryWrapper.Employee.Create(huEmployee);
                huEmployee.Code = CreateCode.EmployeeCode(huEmployee.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huEmployee);
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
                List<HuEmployee> huEmployees = await _repositoryWrapper.Employee.GetAll(request);
                List<EmployeeDTO> employeeDTOs = _mapper.Map<List<EmployeeDTO>>(huEmployees);
                return Response.SuccessResponse(employeeDTOs);
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
                HuEmployee huEmployee = await _repositoryWrapper.Employee.FindById(id);
                if (huEmployee == null)
                    return Response.NotFoundResponse();
                EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(huEmployee);
                return Response.SuccessResponse(employeeDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> Update(UpdateEmployeeDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse();
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployee huEmployee = await _repositoryWrapper.Employee.FindById(update.id);
                if (huEmployee == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, huEmployee);
                await _repositoryWrapper.Employee.Update(huEmployee);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huEmployee);
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
                    HuEmployee huEmployee = await _repositoryWrapper.Employee.FindById(id);
                    if (huEmployee == null)
                    {
                        return Response.NotFoundResponse();
                    }
                }
                foreach (int id in ids)
                {
                    HuEmployee huEmployee = await _repositoryWrapper.Employee.FindById(id);
                    if (huEmployee != null)
                        await _repositoryWrapper.Employee.Delete(huEmployee);
                }
                return Response.SuccessResponse();
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }

        public async Task<BaseResponse> GetAllDataById(int id)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse();
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuEmployee huEmployee = await _repositoryWrapper.Employee.FindById(id);
                if (huEmployee == null)
                    return Response.NotFoundResponse();
                EmployeeInfoDTO employeeDTO = _mapper.Map<EmployeeInfoDTO>(huEmployee);
                _mapper.Map(huEmployee.Contract, employeeDTO.Contract);
                _mapper.Map(huEmployee.OrgNavigation, employeeDTO.OrgNavigation);
                _mapper.Map(huEmployee.HuEmployeeCvs, employeeDTO.HuEmployeeCvs);
                _mapper.Map(huEmployee.HuEmployeeEducations, employeeDTO.HuEmployeeEducations);
                _mapper.Map(huEmployee.HuFamilies, employeeDTO.HuFamilies);
                _mapper.Map(huEmployee.HuShools, employeeDTO.HuShools);
                return Response.SuccessResponse(employeeDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
        }
    }
}
