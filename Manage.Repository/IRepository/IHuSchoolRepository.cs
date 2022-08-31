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
    public interface IHuSchoolRepository : IRepositoryBase<HuSchool>
    {
        Task<List<HuSchool>> GetAll(BaseRequest baseRequest);
    }
}
