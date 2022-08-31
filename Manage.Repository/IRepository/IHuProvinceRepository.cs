using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.District;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuProvinceRepository : IRepositoryBase<HuProvince>
    {
        Task<HuProvince> FindByName(string name);
        Task<List<ListDistrict>> FindAllProvinceById(List<ListDistrict> listDistricts);
        Task<List<HuProvince>> GetAll(BaseRequest baseRequest);
    }
}
