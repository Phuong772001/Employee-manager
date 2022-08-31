using Manage.Common;
using Manage.Model.DTO.OtherListType;

namespace Manage.Service.IService
{
    public interface IOtherListTypeService
    {
        Task<BaseResponse> AddNew(OtherListTypeDTO otherListTypeDTO);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOtherListTypeDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
