using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuContractRepository : IRepositoryBase<HuContract>
    {
        Task<HuContract> FindByName(string name);
        Task<List<HuContract>> GetAll(BaseRequest baseRequest);
    }
}
