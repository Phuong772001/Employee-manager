using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Organization;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuOrganizationRepository : IRepositoryBase<HuOrganization>
    {
        Task<HuOrganization> FindByName(string name);
        Task<List<ListOrganization>> FindAllOrganizationById(List<ListOrganization> listOrganizations);
        public Task<List<ListOrgTitle>> FindAllOrgAndTitleById(List<ListOrgTitle> listOrgTitles);
        Task<List<HuOrganization>> GetAll(BaseRequest baseRequest);
    }
}
