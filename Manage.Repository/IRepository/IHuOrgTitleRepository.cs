using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.OrgTitle;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuOrgTitleRepository : IRepositoryBase<HuOrgTitle>
    {
        Task<List<HuOrgTitle>> GetAll(BaseRequest baseRequest);
    }
}
