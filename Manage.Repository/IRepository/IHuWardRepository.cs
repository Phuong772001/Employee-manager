using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Ward;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuWardRepository : IRepositoryBase<HuWard>
    {
        Task<HuWard> FindByName(string name);
        Task<List<HuWard>> GetAll(BaseRequest baseRequest);
    }
}
