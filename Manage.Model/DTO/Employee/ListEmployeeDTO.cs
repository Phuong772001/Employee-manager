using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Employee
{
    public class ListEmployeeDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool? WorkStatus { get; set; }
        public string DirectManager { get; set; }
        public DateTime? LastWorkingDay { get; set; }
    }
}
