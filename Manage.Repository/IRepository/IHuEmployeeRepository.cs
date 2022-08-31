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
    public interface IHuEmployeeRepository : IRepositoryBase<HuEmployee>
    {
        Task<HuEmployee> FindByName(string name);
        Task<List<HuEmployee>> GetAll(BaseRequest baseRequest);
        Task<HuEmployee> GetAllDataOfUser(int id);
    }
}
