using Manage.Common;
using Manage.Model.DTO.Hospital;

namespace Manage.Service.IService
{
    public interface IHospitalService
    {
        Task<BaseResponse> AddNew(HospitalDTO hospital);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateHospitalDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
