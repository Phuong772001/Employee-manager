using System.Collections.Generic;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using Manage.Model.Models;
using Manage.Repository.Base.IRepository;

namespace Manage.Repository.IRepository
{
    public interface IHuBankRepository : IRepositoryBase<HuBank>
    {
        Task<List<ListBankBranch>> FindAllBankById(List<ListBankBranch> huBankBranches);
        Task<HuBank> FindByName(string name);
        Task<List<HuBank>> GetAll(BaseRequest baseRequest);
    }
}
