using Manage.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Repository.Base.IRepository
{
    public interface IRepositoryWrapper
    {
        IHuAllowanceRepository Allowance { get; }
        IHuBankRepository Bank { get; }
        IHuContractRepository Contract { get; }
        IHuHospitalRepository Hospital { get; }
        IHuNationRepository Nation { get; }
        IHuTitleRepository Title { get; }
        IUserRepository User { get; }
        IHuBankBranchRepository BankBranch { get; }
        IHuContractAllowanceRepository ContractAllowance { get; }
        IHuContractWelfaceRepository ContractWelface { get; }
        IHuDistrictRepository District { get; }
        IHuEmployeeCvRepository EmployeeCv { get; }
        IHuEmployeeEducationRepository EmployeeEducation { get; }
        IHuEmployeeFamilyRepository EmployeeFamily { get; }
        IHuEmployeeRepository Employee { get; }
        IHuOrganizationRepository Organization { get; }
        IHuOrgTitleRepository OrgTitle { get; }
        IHuProvinceRepository Province { get; }
        IHuSalaryRecordRepository SalaryRecord { get; }
        IHuSchoolRepository School { get; }
        IHuWardRepository Ward { get; }
        IHuWelfaceRepository Welface { get; }
        IOtherListRepository OtherList { get; }
        IOtherListTypeRepository OtherListType { get; }

    }
}
