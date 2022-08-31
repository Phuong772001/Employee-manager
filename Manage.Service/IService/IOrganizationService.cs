using Manage.Common;
using Manage.Model.DTO.Organization;

namespace Manage.Service.IService
{
    public interface IOrganizationService
    {
        Task<BaseResponse> AddNew(OrganizationDTO organizationDto);
        Task<BaseResponse> GetAll(BaseRequest request);
        Task<BaseResponse> GetById(int id);
        Task<BaseResponse> Update(UpdateOrganizationDTO update);
        Task<BaseResponse> Delete(List<int> ids);
        Task<BaseResponse> ChangeStatus(int id);
    }
}
