using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuOrgTitleRepository : RepositoryBase<HuOrgTitle>, IHuOrgTitleRepository
    {
        public HuOrgTitleRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<HuOrgTitle>> GetAll(BaseRequest baseRequest)
        {
            return await FindAll()
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
        }
    }
}
