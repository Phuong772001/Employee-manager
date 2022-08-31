using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuContractWelfaceRepository : IRepositoryBase<HuContractWelface>
    {
        Task<List<HuContractWelface>> GetAll(BaseRequest baseRequest);
        Task<HuContractWelface> FindData(int contractId, int welfaceId);
    }
}
