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
    public interface IHuContractAllowanceRepository : IRepositoryBase<HuContractAllowance>
    {
        Task<List<HuContractAllowance>> GetAll(BaseRequest baseRequest);
        Task<HuContractAllowance> FindData(int contractId,int allwanceId);
    }
}
