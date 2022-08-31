using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Employee
{
    public class UpdateEmployeeDTO
    {
        public int id { get; set; }
        public UpdateEmployee updateData { get; set; }
    }
    public class UpdateEmployee
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
        public string Activeflg { get; set; }
    }
}
