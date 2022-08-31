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
    public class HuEmployeeRepository : RepositoryBase<HuEmployee>, IHuEmployeeRepository
    {
        public HuEmployeeRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<HuEmployee> FindByName(string name)
        {
            return await FindByCondition(n => n.FullName.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<HuEmployee>> GetAll(BaseRequest baseRequest)
        {
            if (baseRequest.keyworks != null)
            {
                return await FindAll()
           .Where(n => n.FullName.Equals(baseRequest.keyworks))
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
            }

            return await FindAll()
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
        }

        public async Task<HuEmployee> GetAllDataOfUser(int id)
        {
            return await FindByCondition(i => i.Id.Equals(id))
                .Include(u => u.HuEmployeeCvs)
                .Include(u => u.HuEmployeeEducations)
                .Include(u => u.HuFamilies)
                .Include(u => u.HuShools)
                .Include(u => u.OrgNavigation)
                .Include(u => u.Contract)
                .FirstOrDefaultAsync();
        }
    }
}
