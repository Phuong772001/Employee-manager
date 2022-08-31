using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Nation;
using Manage.Model.DTO.Province;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuNationRepository : IRepositoryBase<HuNation>
    {
        Task<HuNation> FindByName(string name);
        Task<List<ListProvince>> FindAllNationById(List<ListProvince> listProvinces);
        Task<List<HuNation>> GetAll(BaseRequest baseRequest);
    }
}
