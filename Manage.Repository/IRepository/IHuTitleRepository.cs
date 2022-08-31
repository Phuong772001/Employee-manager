using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.DTO.Title;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuTitleRepository : IRepositoryBase<HuTitle>
    {
        Task<HuTitle> FindByName(string name);
        Task<List<ListOrgTitle>> FindAllOrgAndTitleById(List<ListOrgTitle> listOrgTitles);
        Task<List<HuTitle>> GetAll(BaseRequest baseRequest);
    }
}
