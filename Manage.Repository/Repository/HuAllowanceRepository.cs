using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Allowance;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuAllowanceRepository : RepositoryBase<HuAllowance>, IHuAllowanceRepository
    {
        public HuAllowanceRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<HuAllowance> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public HuAllowance FindByName2(string name)
        {
            return FindByCondition(n => n.Name.Equals(name)).FirstOrDefault();
        }

        public async Task<List<HuAllowance>> GetAll(BaseRequest baseRequest)
        {
            if (baseRequest.keyworks != null)
            {
                return await FindAll()
              .Where(n => n.Name.Equals(baseRequest.keyworks) && n.Activeflg.Equals("A"))
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
