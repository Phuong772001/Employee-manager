using Manage.Common;
using Manage.Model.DTO.Allowance;


namespace Manage.Service.IService
{
    public interface IAllowanceService 
    {
        Task<BaseResponse> AddNew(AllowanceDTO allowance);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateAllowanceDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
