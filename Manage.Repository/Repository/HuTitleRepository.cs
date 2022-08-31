using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.DTO.Title;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuTitleRepository : RepositoryBase<HuTitle>, IHuTitleRepository
    {
        public HuTitleRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<ListOrgTitle>> FindAllOrgAndTitleById(List<ListOrgTitle> listOrgTitles)
        {
            foreach (ListOrgTitle listOrgTitle in listOrgTitles)
            {
                HuTitle huTitle = await FindById(listOrgTitle.TitleId);
                listOrgTitle.Title = huTitle.Name;
            }
            return listOrgTitles;
        }

        public async Task<HuTitle> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<HuTitle>> GetAll(BaseRequest baseRequest)
        {
            if (baseRequest.keyworks != null)
            {
                return await FindAll()
           .Where(n => n.Name.Equals(baseRequest.keyworks))
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
    }
}
