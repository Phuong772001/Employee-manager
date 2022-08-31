using AutoMapper;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.District;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.Service
{
    public class DistrictService : IDistrictService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DistrictService(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BaseResponse> AddNew(DistrictDTO districtDto)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuDistrict huDistrict = await _repositoryWrapper.District.FindByName(districtDto.Name);
                if (huDistrict != null) return Response.DuplicateDataResponse("district already exist");
                HuProvince huProvince = await _repositoryWrapper.Province.FindByName(districtDto.ProvinceName);
                if (huProvince == null) return Response.NotFoundResponse();
                huDistrict = _mapper.Map<HuDistrict>(districtDto);
                huDistrict.ProvinceId = huProvince.Id;
                await _repositoryWrapper.District.Create(huDistrict);
                huDistrict.Code = CreateCode.DistrictCode(huDistrict.Id);
                UserInfoCreate userInfoCreate = UserCreateAndUpdate.GetUserInfoCreate(tokenDecode);
                _mapper.Map(userInfoCreate, huDistrict);
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
                List<HuDistrict> huDistricts = await _repositoryWrapper.District.GetAll(request);
                List<ListDistrict> listDistricts = _mapper.Map<List<ListDistrict>>(huDistricts);
                listDistricts = await _repositoryWrapper.Province.FindAllProvinceById(listDistricts);
                List<ListDistrictDTO> listDistrictDTOs = _mapper.Map<List<ListDistrictDTO>>(listDistricts);
                return Response.SuccessResponse(listDistrictDTOs);
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
                HuDistrict huDistrict = await _repositoryWrapper.District.FindById(id);
                if (huDistrict == null)
                    return Response.NotFoundResponse();
                HuProvince huProvince = await _repositoryWrapper.Province.FindById(huDistrict.ProvinceId);
                DistrictDTO districtDTO = _mapper.Map<DistrictDTO>(huDistrict);
                districtDTO.ProvinceName = huProvince.Name;
                return Response.SuccessResponse(districtDTO);
            }
            catch (Exception ex)
            {
                return Response.ExceptionResponse(ex);
            }
            
        }

        public async Task<BaseResponse> Update(UpdateDistrictDTO update)
        {
            try
            {
                bool isHasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token); if (isHasToken == false) return Response.AuthHeaderResponse(); 
                TokenConfiguration tokenConfiguration = new TokenConfiguration(_configuration);
                TokenDecode tokenDecode = tokenConfiguration.TokenInfo(token);
                BaseResponse tokenResponse = tokenConfiguration.CheckToken(tokenDecode);
                if (tokenResponse != null)
                    return tokenResponse;
                HuDistrict huDistrict = await _repositoryWrapper.District.FindById(update.Id);
                if (huDistrict == null)
                    return Response.NotFoundResponse();
                _mapper.Map(update.updateData, huDistrict);
                HuProvince huProvince = await _repositoryWrapper.Province.FindByName(update.updateData.ProvinceName);
                if (huProvince == null) return Response.NotFoundResponse("province not exist");
                huDistrict.ProvinceId = huProvince.Id;
                await _repositoryWrapper.District.Update(huDistrict);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huDistrict);
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
                    HuDistrict huDistrict = await _repositoryWrapper.District.FindById(id);
                    if (huDistrict == null)
                    {
                        return Response.NotFoundResponse();
                    }

                }
                foreach (int id in ids)
                {
                    HuDistrict huDistrict = await _repositoryWrapper.District.FindById(id);
                    if (huDistrict != null)
                        await _repositoryWrapper.District.Delete(huDistrict);
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
                HuDistrict huDistrict = await _repositoryWrapper.District.FindById(id);
                if (huDistrict == null)
                    return Response.NotFoundResponse();
                huDistrict.Activeflg = Tools.ChangeStatus(huDistrict.Activeflg);
                await _repositoryWrapper.District.Update(huDistrict);
                UserInfoUpdate userInfoUpdate = UserCreateAndUpdate.GetUserInfoUpdate(tokenDecode);
                _mapper.Map(userInfoUpdate, huDistrict);
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
