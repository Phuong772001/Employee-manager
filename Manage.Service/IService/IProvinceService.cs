using Manage.Common;
using Manage.Model.DTO.Province;

namespace Manage.Service.IService
{
    public interface IProvinceService
    {
        Task<BaseResponse> AddNew(ProvinceDTO provinceDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateProvinceDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
