using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuContractWelfaceRepository : RepositoryBase<HuContractWelface>, IHuContractWelfaceRepository
    {
        public HuContractWelfaceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<HuContractWelface> FindData(int contractId, int welfaceId)
        {
            return await FindByCondition(a => a.ContractId.Equals(contractId) && a.WelfaceId.Equals(welfaceId))
               .FirstOrDefaultAsync();
        }

        public async Task<List<HuContractWelface>> GetAll(BaseRequest baseRequest)
        {
            return await  FindAll()
           .Where(n =>n.Activeflg.Equals("A"))
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
        }
    }
}
