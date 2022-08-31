using Manage.Common;
using Manage.Model.DTO.OtherList;

namespace Manage.Service.IService
{
    public interface IOtherListService
    {
        Task<BaseResponse> AddNew(OtherListDTO otherListDTO);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOtherListDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
