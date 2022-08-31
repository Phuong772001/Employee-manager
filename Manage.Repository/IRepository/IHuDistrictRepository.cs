using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Ward;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuDistrictRepository : IRepositoryBase<HuDistrict>
    {
        Task<HuDistrict> FindByName(string name);
        Task<List<ListWard>> FindAllDistrictById(List<ListWard> listWards);
        Task<List<HuDistrict>> GetAll(BaseRequest baseRequest);
    }
}
