using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Organization;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuOrganizationRepository : RepositoryBase<HuOrganization>, IHuOrganizationRepository
    {
        public HuOrganizationRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<ListOrgTitle>> FindAllOrgAndTitleById(List<ListOrgTitle> listOrgTitles)
        {
            foreach (ListOrgTitle listOrgTitle in listOrgTitles)
            {
                HuOrganization huOrganization = await FindById(listOrgTitle.OrgId);
                listOrgTitle.Org = huOrganization.Name;
            }
            return listOrgTitles;
        }

        public async Task<List<ListOrganization>> FindAllOrganizationById(List<ListOrganization> listOrganizations)
        {
            foreach (ListOrganization listOrganization in listOrganizations)
            {
                if (listOrganization.ParentId == 0)
                    listOrganization.Parent = "none";
                else
                {
                    HuOrganization huOrganization = await FindById(listOrganization.ParentId);
                    listOrganization.Parent = huOrganization.Name;
                }
                
            }
            return listOrganizations;
        }

        public async Task<HuOrganization> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<HuOrganization>> GetAll(BaseRequest baseRequest)
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
