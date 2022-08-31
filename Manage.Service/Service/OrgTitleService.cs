using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class OrgTitleService : IOrgTitleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrgTitleService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(OrgTitleDTO orgTitleDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuOrganization huOrganization = await _repositoryWrapper.Organization.FindByName(orgTitleDto.Org);
                if (huOrganization == null) return Response.NotFoundResponse("organization not exist");
                HuTitle huTitle = await _repositoryWrapper.Title.FindByName(orgTitleDto.Title);
                if (huTitle == null) return Response.NotFoundResponse("title not exist");
                HuOrgTitle HuOrgTitle = new HuOrgTitle
                {
                    OrgId = huOrganization.Id,
                    TitleId = huTitle.Id,
                };
                await _repositoryWrapper.OrgTitle.Create(HuOrgTitle);
                HuOrgTitle.Code = CreateCode.OrgTitleCode(HuOrgTitle.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, HuOrgTitle);
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
                List<HuOrgTitle> HuOrgTitles = await _repositoryWrapper.OrgTitle.GetAll(request);
                List<ListOrgTitle> listOrgTitles = _mapper.Map<List<ListOrgTitle>>(HuOrgTitles);
                listOrgTitles = await _repositoryWrapper.Organization.FindAllOrgAndTitleById(listOrgTitles);
                listOrgTitles = await _repositoryWrapper.Title.FindAllOrgAndTitleById(listOrgTitles);
                List<ListOrgTitleDTO> listOrgTitleDTOs = _mapper.Map<List<ListOrgTitleDTO>>(listOrgTitles);
                return Response.SuccessResponse(listOrgTitleDTOs);
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
                HuOrgTitle HuOrgTitle = await _repositoryWrapper.OrgTitle.FindById(id);
                if (HuOrgTitle == null)
                    return Response.NotFoundResponse();
                HuOrganization huOrganization = await _repositoryWrapper.Organization.FindById(HuOrgTitle.OrgId);
                HuTitle huTitle = await _repositoryWrapper.Title.FindById(id);
                if (HuOrgTitle == null)
                    return Response.NotFoundResponse();
                OrgTitleDTO orgTitleDTO = new OrgTitleDTO
                {
                    Org = huOrganization.Name,
                    Title = huTitle.Name,
                };
                return Response.SuccessResponse(orgTitleDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Update(UpdateOrgTitleDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuOrgTitle huOrgTitle = await _repositoryWrapper.OrgTitle.FindById(update.id);
               
                if (huOrgTitle == null)
                    return Response.NotFoundResponse();
                HuTitle huTitle = await _repositoryWrapper.Title.FindByName(update.updateData.Title);
                HuOrganization huOrganization = await _repositoryWrapper.Organization.FindByName(update.updateData.Org);
                _mapper.Map(update.updateData, huOrgTitle);
                huOrgTitle.OrgId = huOrganization.Id;
                huOrgTitle.TitleId = huOrganization.Id;
                await _repositoryWrapper.OrgTitle.Update(huOrgTitle);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huOrgTitle);
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
                    HuOrgTitle huOrgTitle = await _repositoryWrapper.OrgTitle.FindById(id);
                    if (huOrgTitle == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuOrgTitle huOrgTitle = await _repositoryWrapper.OrgTitle.FindById(id);
                    if (huOrgTitle != null)
                        await _repositoryWrapper.OrgTitle.Delete(huOrgTitle);
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
