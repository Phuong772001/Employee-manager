using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Organization;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrganizationService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(OrganizationDTO organizationDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                if (await _repositoryWrapper.Organization.FindByName(organizationDto.Name) != null)
                    return Response.DuplicateDataResponse("organization already exist");
                HuOrganization huOrganizationParent = await _repositoryWrapper.Organization.FindByName(organizationDto.ParentName);
                if (huOrganizationParent == null && organizationDto.ParentName != null)
                    return Response.NotFoundResponse("organization parent not exist");
                HuOrganization HuOrganization = _mapper.Map<HuOrganization>(organizationDto);
                await _repositoryWrapper.Organization.Create(HuOrganization);
                HuOrganization.Code = CreateCode.OrgCode(HuOrganization.Id);
                HuOrganization.OrderNumber = HuOrganization.Id;
                if (organizationDto.ParentName != null)
                    HuOrganization.ParentId = huOrganizationParent.Id;
                else HuOrganization.ParentId = 0;
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, HuOrganization);
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
                List<HuOrganization> HuOrganizations = await _repositoryWrapper.Organization.GetAll(request);
                List<ListOrganization> listOrganizations = _mapper.Map<List<ListOrganization>>(HuOrganizations);
                listOrganizations = await _repositoryWrapper.Organization.FindAllOrganizationById(listOrganizations);
                List<ListOrganizationDTO> listOrganizationDTOs = _mapper.Map<List<ListOrganizationDTO>>(listOrganizations);
                return Response.SuccessResponse(listOrganizationDTOs);
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
                HuOrganization HuOrganization = await _repositoryWrapper.Organization.FindById(id);
                if (HuOrganization == null)
                    return Response.NotFoundResponse();
                HuOrganization HuOrganizationParent = await _repositoryWrapper.Organization.FindById(HuOrganization.ParentId);
                OrganizationDTO organizationDTO = _mapper.Map<OrganizationDTO>(HuOrganization);
                if (HuOrganization.ParentId != 0)
                    organizationDTO.ParentName = HuOrganizationParent.Name;
                else organizationDTO.ParentName = "none";
                return Response.SuccessResponse(organizationDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
           
        }

        public async Task<BaseResponse> Update(UpdateOrganizationDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuOrganization huOrganization = await _repositoryWrapper.Organization.FindById(update.id);
                if (huOrganization == null)
                    return Response.NotFoundResponse();
                HuOrganization huOrganizationParent = await _repositoryWrapper.Organization.FindByName(update.updateData.ParentName);
                if(huOrganizationParent == null && update.updateData.ParentName != null)
                return Response.NotFoundResponse("Organization not exist");
                _mapper.Map(update.updateData, huOrganization);
                
                await _repositoryWrapper.Organization.Update(huOrganization);
                if (update.updateData.ParentName != null)
                    huOrganization.ParentId = huOrganizationParent.Id;
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huOrganization);
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
                    HuOrganization huOrganization = await _repositoryWrapper.Organization.FindById(id);
                    if (huOrganization == null)
                    {
                        return Response.NotFoundResponse($"organization with id {id} not exist");
                    }

                }
                foreach (int id in ids)
                {
                    HuOrganization huOrganization = await _repositoryWrapper.Organization.FindById(id);
                    if (huOrganization != null)
                        await _repositoryWrapper.Organization.Delete(huOrganization);
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
                HuOrganization huOrganization = await _repositoryWrapper.Organization.FindById(id);
                if (huOrganization == null)
                    return Response.NotFoundResponse();
                huOrganization.Activeflg = Tools.ChangeStatus(huOrganization.Activeflg);
                await _repositoryWrapper.Organization.Update(huOrganization);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huOrganization);
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
