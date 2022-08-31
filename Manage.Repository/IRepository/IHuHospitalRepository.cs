using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Hospital;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuHospitalRepository : IRepositoryBase<HuHospital>
    {
        Task<List<HuHospital>> FindByName(string name);
        Task<List<HuHospital>> GetAll(BaseRequest baseRequest);
        Task<HuHospital> FindByAddress(string address);
    }
}
