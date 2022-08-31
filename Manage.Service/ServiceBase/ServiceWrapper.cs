using AutoMapper;
using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Manage.Service.IService;
using Manage.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Manage.Service.ServiceBase
{
    public class ServiceWrapper: IServiceWrapper
    {
        public readonly IMapper _mapper;
        public readonly IRepositoryWrapper _repositoryWrapper;
        public readonly DatabaseContext _context;
        public readonly IConfiguration _configuration;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public IAllowanceService _allowance;
        public IBankBranchService _bankBranch;
        public IBankService _bank;
        public IContractAllowanceService _contractAllowance;
        public IContractService _contract;
        public IContractualBenefitService _contractualBenefit;
        public IDistrictService _district;
        public IEmployeeCvService _employeeCv;
        public IEmployeeEducationService _employeeEducation;
        public IEmployeeFamilyService _employeeFamily;
        public IEmployeeService _employee;
        public IHospitalService _hospital;
        public INationService _nation;
        public IOrganizationService _organization;
        public IOrgTitleService _orgTitle;
        public ISalaryRecordService _salaryRecord;
        public IProvinceService _province;
        public ISchoolService _school;
        public ITitleService _title;
        public IUserService _user;
        public IWardService _ward;
        public IWelfaceService _welface;
        public IOtherListService _otherList;
        public IOtherListTypeService _otherListType;

        public IAllowanceService Allowance
        {
            get
            {
                if (_allowance == null)
                    _allowance = new AllowanceService(_mapper, _repositoryWrapper,
                       _context, _configuration,_httpContextAccessor);
                return _allowance;
            }
        }

        public IBankBranchService BankBranch
        {
            get
            {
                if (_bankBranch == null)
                    _bankBranch = new BankBranchService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _bankBranch;
            }
        }

        public IBankService Bank
        {
            get
            {
                if (_bank == null)
                    _bank = new BankService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _bank;
            }
        }

        public IContractAllowanceService ContractAllowance
        {
            get
            {
                if (_contractAllowance == null)
                    _contractAllowance = new ContractAllowanceService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _contractAllowance;
            }
        }

        public IContractualBenefitService ContractualBenefit
        {
            get
            {
                if (_contractualBenefit == null)
                    _contractualBenefit = new ContractualBenefitService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _contractualBenefit;
            }
        }

        public IDistrictService District
        {
            get
            {
                if (_district == null)
                    _district = new DistrictService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _district;
            }
        }

        public IEmployeeCvService EmployeeCv
        {
            get
            {
                if (_employeeCv == null)
                    _employeeCv = new EmployeeCvService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _employeeCv;
            }
        }

        public IEmployeeEducationService EmployeeEducation
        {
            get
            {
                if (_employeeEducation == null)
                    _employeeEducation = new EmployeeEducationService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _employeeEducation;
            }
        }

        public IEmployeeFamilyService EmployeeFamily
        {
            get
            {
                if (_employeeFamily == null)
                    _employeeFamily = new EmployeeFamilyService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _employeeFamily;
            }
        }
        public IEmployeeService Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new EmployeeService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _employee;
            }
        }

        public IHospitalService Hospital
        {
            get
            {
                if (_hospital == null)
                    _hospital = new HospitalService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _hospital;
            }
        }

        public INationService Nation
        {
            get
            {
                if (_nation == null)
                    _nation = new NationService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _nation;
            }
        }

        public IOrganizationService Organization
        {
            get
            {
                if (_organization == null)
                    _organization = new OrganizationService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _organization;
            }
        }

        public IOrgTitleService OrgTitle
        {
            get
            {
                if (_orgTitle == null)
                    _orgTitle = new OrgTitleService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _orgTitle;
            }
        }

        public ISalaryRecordService SalaryRecord
        {
            get
            {
                if (_salaryRecord == null)
                    _salaryRecord = new SalaryRecordService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _salaryRecord;
            }
        }

        public IProvinceService Province
        {
            get
            {
                if (_province == null)
                    _province = new ProvinceService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _province;
            }
        }

        public ISchoolService School
        {
            get
            {
                if (_school == null)
                    _school = new SchoolService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _school;
            }
        }

        public ITitleService Title
        {
            get
            {
                if (_title == null)
                    _title = new TitleService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _title;
            }
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                    _user = new UserService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _user;
            }
        }

        public IWardService Ward
        {
            get
            {
                if (_ward == null)
                    _ward = new WardService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _ward;
            }
        }

        public IWelfaceService Welface
        {
            get
            {
                if (_welface == null)
                    _welface = new WelfaceService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _welface;
            }
        }

        public IContractService Contract
        {
            get
            {
                if (_contract == null)
                    _contract = new ContractService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _contract;
            }
        }

        public IOtherListService OtherList
        {
            get
            {
                if (_otherList == null)
                    _otherList = new OtherListService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _otherList;
            }
        }

        public IOtherListTypeService OtherListType
        {
            get
            {
                if (_otherListType == null)
                    _otherListType = new OtherListTypeService(_mapper, _repositoryWrapper,
                       _context, _configuration, _httpContextAccessor);
                return _otherListType;
            }
        }

        public ServiceWrapper(IMapper mapper, IRepositoryWrapper repositoryWrapper, DatabaseContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
