using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeFamily
{
    public class EmployeeFamilyDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        public int? IdNo { get; set; }
        [Required]
        public string IsDeduct { get; set; }
        [Required]
        public DateTime? DeductFrom { get; set; }
        [Required]
        public DateTime? DeductTo { get; set; }
        [Required]
        public string Remark { get; set; }

    }
}
