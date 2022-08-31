using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Service.IService
{
    public interface IServiceWrapper
    {
        IAllowanceService Allowance { get; }
        IBankBranchService BankBranch { get; }
        IBankService Bank { get; }
        IContractAllowanceService ContractAllowance { get; }
        IContractService Contract { get; }
        IContractualBenefitService ContractualBenefit { get; }
        IDistrictService District { get; }
        IEmployeeCvService EmployeeCv { get; }
        IEmployeeEducationService EmployeeEducation { get; }
        IEmployeeFamilyService EmployeeFamily { get; }
        IEmployeeService Employee { get; }
        IHospitalService Hospital { get; }
        INationService Nation { get; }
        IOrganizationService Organization { get; }
        IOrgTitleService OrgTitle { get; }
        ISalaryRecordService SalaryRecord { get; }
        IProvinceService Province { get; }
        ISchoolService School { get; }
        ITitleService Title { get; }
        IUserService User { get; }
        IWardService Ward { get; }
        IWelfaceService Welface { get; }
        IOtherListService OtherList { get; }
        IOtherListTypeService OtherListType { get; }



    }
}
