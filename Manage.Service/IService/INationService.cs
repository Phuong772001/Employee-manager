using Manage.Common;
using Manage.Model.DTO.Nation;

namespace Manage.Service.IService
{
    public interface INationService
    {
        Task<BaseResponse> AddNew(NationDTO nation);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateNationDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
