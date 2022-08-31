using Manage.Common;
using Manage.Model.DTO.Contract;

namespace Manage.Service.IService
{
    public interface IContractService
    {
        Task<BaseResponse> AddNew(ContractDTO contractDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateContractDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
