using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.SalaryRecord
{
    public class SalaryRecordDTO
    {
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public int? ContracId { get; set; }
        [Required]
        public int? ContractAllwanceId { get; set; }
        [Required]
        public int? ContractWelfaceId { get; set; }
        [Required]
        public double? Money { get; set; }
    }
}
