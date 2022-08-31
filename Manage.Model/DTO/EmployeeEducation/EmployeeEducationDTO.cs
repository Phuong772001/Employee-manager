using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeEducation
{
    public class EmployeeEducationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public DateTime? FisrtDate { get; set; }
        [Required]
        public DateTime? FinsishDate { get; set; }
    }
}
