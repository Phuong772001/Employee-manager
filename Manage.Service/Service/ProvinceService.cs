using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Province;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class ProvinceService : IProvinceService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProvinceService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(ProvinceDTO provinceDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuProvince huProvince = await _repositoryWrapper.Province.FindByName(provinceDto.Name);
                if (huProvince != null) return Response.NotFoundResponse("province already exist");
                HuNation huNation = await _repositoryWrapper.Nation.FindByName(provinceDto.NationName);
                if (huNation == null) return Response.NotFoundResponse("nation not exist");
                huProvince = _mapper.Map<HuProvince>(provinceDto);
                huProvince.NationId = huNation.Id;
                await _repositoryWrapper.Province.Create(huProvince);
                huProvince.Code = CreateCode.ProvinceCode(huProvince.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huProvince);
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
                List<HuProvince> huProvinces = await _repositoryWrapper.Province.GetAll(request);
                List<ListProvince> listProvinces = _mapper.Map<List<ListProvince>>(huProvinces);
                listProvinces = await _repositoryWrapper.Nation.FindAllNationById(listProvinces);
                List<ListProvinceDTO> listProvinceDtos = _mapper.Map<List<ListProvinceDTO>>(listProvinces);
                return Response.SuccessResponse(listProvinceDtos);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> GetById(int id)
        {
            bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
            TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
            TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
            BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
            if (tokenResponse != null)
                return tokenResponse;
            HuProvince huProvince = await _repositoryWrapper.Province.FindById(id);
            if (huProvince == null)
                return Response.NotFoundResponse();
            HuNation huNation = await _repositoryWrapper.Nation.FindById(huProvince.NationId);
            ProvinceDTO province = _mapper.Map<ProvinceDTO>(huProvince);
            province.NationName = huNation.Name;
            return Response.SuccessResponse(province);
        }

        public async Task<BaseResponse> Update(UpdateProvinceDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuProvince huProvince = await _repositoryWrapper.Province.FindById(update.Id);
                if (huProvince == null)
                    return Response.NotFoundResponse();
                HuNation huNation = await _repositoryWrapper.Nation.FindByName(update.updateData.Nation);
                _mapper.Map(update.updateData, huProvince);
                huProvince.NationId = huNation.Id;
                await _repositoryWrapper.Province.Update(huProvince);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huProvince);
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
                    HuProvince huProvince = await _repositoryWrapper.Province.FindById(id);
                    if (huProvince == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuProvince huProvince = await _repositoryWrapper.Province.FindById(id);
                    if (huProvince != null)
                        await _repositoryWrapper.Province.Delete(huProvince);
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
                HuProvince huProvince = await _repositoryWrapper.Province.FindById(id);
                if (huProvince == null)
                    return Response.NotFoundResponse();
                huProvince.Activeflg = Tools.ChangeStatus(huProvince.Activeflg);
                await _repositoryWrapper.Province.Update(huProvince);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huProvince);
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
