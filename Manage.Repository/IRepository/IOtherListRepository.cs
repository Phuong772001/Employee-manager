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
    public interface IOtherListRepository : IRepositoryBase<OtherList>
    {
        Task<OtherList> FindByName(string name);
        Task<List<OtherList>> GetAll(BaseRequest baseRequest);
    }
}
