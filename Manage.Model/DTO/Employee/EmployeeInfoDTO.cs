using Manage.Model.DTO.Contract;
using Manage.Model.DTO.EmployeeCv;
using Manage.Model.DTO.EmployeeEducation;
using Manage.Model.DTO.EmployeeFamily;
using Manage.Model.DTO.Organization;
using Manage.Model.DTO.School;
using Manage.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Employee
{
    public class EmployeeInfoDTO
    {

        public string FullName { get; set; }
 
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
     
        public int? OrgId { get; set; }
  
        public DateTime? JoinDate { get; set; }
     
        public bool? WorkStatus { get; set; }
     
        public int? ContractId { get; set; }
        
        public int? TitleId { get; set; }
        
        public int? WorkingId { get; set; }
        
        public string DirectManager { get; set; }
       
        public int? ItimeId { get; set; }
        
        public int? LastWorkingId { get; set; }
        
        public DateTime? LastWorkingDay { get; set; }


        public virtual ContractDTO Contract { get; set; }

        public virtual OrganizationDTO OrgNavigation { get; set; }


        public virtual EmployeeCvDTO HuEmployeeCvs { get; set; }

        public virtual EmployeeEducationDTO HuEmployeeEducations { get; set; }

        public virtual EmployeeFamilyDTO HuFamilies { get; set; }


        public virtual SchoolDTO HuShools { get; set; }
    }
}
