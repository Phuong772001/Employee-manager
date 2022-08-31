using Manage.Common;
using Manage.Model.DTO.EmployeeCv;

namespace Manage.Service.IService
{
    public interface IEmployeeCvService
    {
        Task<BaseResponse> AddNew(EmployeeCvDTO employeeCvDto);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateEmployeeCvDTO update);
        Task<BaseResponse> Delete(List<int> ids);
    }
}
