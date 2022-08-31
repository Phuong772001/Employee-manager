using Manage.Common;
using Manage.Model.DTO.Bank;


namespace Manage.Service.IService
{
    public interface IBankService
    {
        Task<BaseResponse> AddNew(BankDTO bank);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateBankDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
