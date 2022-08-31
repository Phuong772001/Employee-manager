using Manage.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Employee
{
    public class EmployeeDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int? OrgId { get; set; }
        [Required]
        public DateTime? JoinDate { get; set; }
        [Required]
        public bool? WorkStatus { get; set; }
        [Required]
        public int? ContractId { get; set; }
        [Required]
        public int? TitleId { get; set; }
        [Required]
        public int? WorkingId { get; set; }
        [Required]
        public string DirectManager { get; set; }
        [Required]
        public int? ItimeId { get; set; }
        [Required]
        public int? LastWorkingId { get; set; }
        [Required]
        public DateTime? LastWorkingDay { get; set; }

        


    }
}
