using Manage.Common;
using Manage.Model.DTO.BankBranch;

namespace Manage.Service.IService
{
    public interface IBankBranchService
    {
        Task<BaseResponse> AddNew(BankBranchDTO bankBranch);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateBankBranchDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
