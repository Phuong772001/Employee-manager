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
    public class HuBankBranchRepository : RepositoryBase<HuBankBranch>, IHuBankBranchRepository
    {
        public HuBankBranchRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<HuBankBranch> FindAddress(string address)
        {
            return await FindByCondition(a => a.Address.Equals(address)).FirstOrDefaultAsync();
        }

        public async Task<List<HuBankBranch>> GetAll(BaseRequest baseRequest)
        {
            if (baseRequest.keyworks != null)
            {
                    return await FindAll()
              .Where(n => n.Bank.Name.Equals(baseRequest.keyworks) && n.Activeflg.Equals("A"))
              .OrderBy(a => a.Id)
              .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
              .Take(baseRequest.pageSize)
              .ToListAsync();
            }
            return await FindAll()
          .Where(n => n.Activeflg.Equals("A"))
          .OrderBy(a => a.Id)
          .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
          .Take(baseRequest.pageSize)
          .ToListAsync();
        }
    }
}
