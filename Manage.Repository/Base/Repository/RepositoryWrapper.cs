using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Repository.IRepository;
using Manage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Repository.Base.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        public DatabaseContext _context;
        public IHuAllowanceRepository _allowance;
        public IHuBankRepository _bank;
        public IHuContractRepository _contract;
        public IHuHospitalRepository _hospital;
        public IHuNationRepository _nation;
        public IHuTitleRepository _title;
        public IUserRepository _user;
        public IHuBankBranchRepository _bankBranch;
        public IHuContractAllowanceRepository _contractAllowance;
        public IHuContractWelfaceRepository _contractWelface;
        public IHuDistrictRepository _district;
        public IHuEmployeeCvRepository _employeeCv;
        public IHuEmployeeEducationRepository _employeeEducation;
        public IHuEmployeeFamilyRepository _employeeFamily;
        public IHuEmployeeRepository _employee;
        public IHuOrganizationRepository _organization;
        public IHuOrgTitleRepository _orgTitle;
        public IHuProvinceRepository _province;
        public IHuSalaryRecordRepository _salaryRecord;
        public IHuSchoolRepository _school;
        public IHuWardRepository _ward;
        public IHuWelfaceRepository _welface;
        public IOtherListRepository _otherList;
        public IOtherListTypeRepository _otherListType;

        public IHuAllowanceRepository Allowance
        {
            get
            {
                if (_allowance == null)
                    _allowance = new HuAllowanceRepository(_context);
                return _allowance;
            }
        }

        public IHuBankRepository Bank
        {
            get
            {
                if (_bank == null)
                    _bank = new HuBankRepository(_context);
                return _bank;
            }
        }

        public IHuContractRepository Contract
        {
            get
            {
                if (_contract == null)
                    _contract = new HuContractRepository(_context);
                return _contract;
            }
        }

        public IHuHospitalRepository Hospital
        {
            get
            {
                if (_hospital == null)
                    _hospital = new HuHospitalRepository(_context);
                return _hospital;
            }
        }

        public IHuNationRepository Nation
        {
            get
            {
                if (_nation == null)
                    _nation = new HuNationRepository(_context);
                return _nation;
            }
        }

        public IHuTitleRepository Title
        {
            get
            {
                if (_title == null)
                    _title = new HuTitleRepository(_context);
                return _title;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_context);
                return _user;
            }
        }

        public IHuBankBranchRepository BankBranch
        {
            get
            {
                if (_bankBranch == null)
                    _bankBranch = new HuBankBranchRepository(_context);
                return _bankBranch;
            }
        }

        public IHuContractAllowanceRepository ContractAllowance
        {
            get
            {
                if (_contractAllowance == null)
                    _contractAllowance = new HuContractAllowanceRepository(_context);
                return _contractAllowance;
            }
        }

        public IHuContractWelfaceRepository ContractWelface
        {
            get
            {
                if (_contractWelface == null)
                    _contractWelface = new HuContractWelfaceRepository(_context);
                return _contractWelface;
            }
        }

        public IHuDistrictRepository District
        {
            get
            {
                if (_district == null)
                    _district = new HuDistrictRepository(_context);
                return _district;
            }
        }

        public IHuEmployeeCvRepository EmployeeCv
        {
            get
            {
                if (_employeeCv == null)
                    _employeeCv = new HuEmployeeCvRepository(_context);
                return _employeeCv;
            }
        }

        public IHuEmployeeEducationRepository EmployeeEducation
        {
            get
            {
                if (_employeeEducation == null)
                    _employeeEducation = new HuEmployeeEducationRepository(_context);
                return _employeeEducation;
            }
        }

        public IHuEmployeeFamilyRepository EmployeeFamily
        {
            get
            {
                if (_employeeFamily == null)
                    _employeeFamily = new HuEmployeeFamilyRepository(_context);
                return _employeeFamily;
            }
        }

        public IHuEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new HuEmployeeRepository(_context);
                return _employee;
            }
        }

        public IHuOrganizationRepository Organization
        {
            get
            {
                if (_organization == null)
                    _organization = new HuOrganizationRepository(_context);
                return _organization;
            }
        }

        public IHuOrgTitleRepository OrgTitle
        {
            get
            {
                if (_orgTitle == null)
                    _orgTitle = new HuOrgTitleRepository(_context);
                return _orgTitle;
            }
        }

        public IHuProvinceRepository Province
        {
            get
            {
                if (_province == null)
                    _province = new HuProvinceRepository(_context);
                return _province;
            }
        }

        public IHuSalaryRecordRepository SalaryRecord
        {
            get
            {
                if (_salaryRecord == null)
                    _salaryRecord = new HuSalaryRecordRepository(_context);
                return _salaryRecord;
            }
        }

        public IHuSchoolRepository School
        {
            get
            {
                if (_school == null)
                    _school = new HuSchoolRepository(_context);
                return _school;
            }
        }

        public IHuWardRepository Ward
        {
            get
            {
                if (_ward == null)
                    _ward = new HuWardRepository(_context);
                return _ward;
            }
        }

        public IHuWelfaceRepository Welface
        {
            get
            {
                if (_welface == null)
                    _welface = new HuWelfaceRepository(_context);
                return _welface;
            }
        }

        public IOtherListRepository OtherList
        {
            get
            {
                if (_otherList == null)
                    _otherList = new OtherListRepository(_context);
                return _otherList;
            }
        }

        public IOtherListTypeRepository OtherListType
        {
            get
            {
                if (_otherListType == null)
                    _otherListType = new OtherListTypeRepository(_context);
                return _otherListType;
            }
        }

        public RepositoryWrapper(DatabaseContext context)
        {
            _context = context;

        }
    }
}
