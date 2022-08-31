using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuBankBranchRepository : IRepositoryBase<HuBankBranch>
    {
        Task<List<HuBankBranch>> GetAll(BaseRequest baseRequest);
        Task<HuBankBranch> FindAddress(string address);
    }
}
