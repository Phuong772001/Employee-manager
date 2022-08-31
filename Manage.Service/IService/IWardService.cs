using Manage.Common;
using Manage.Model.DTO.Ward;

namespace Manage.Service.IService
{
    public interface IWardService
    {
        Task<BaseResponse> AddNew(WardDTO wardDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateWardDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
