using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.School
{
    public class SchoolDTO
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        [Required]
        public int? YearGra { get; set; }
        [Required]
        public string Schools { get; set; }
        [Required]
        public string Certificate { get; set; }
        [Required]
        public DateTime? CertificateFromDate { get; set; }
        [Required]
        public DateTime? CertificateTodate { get; set; }
        [Required]
        public string TrainForm { get; set; }
        [Required]
        public int? EmployeeId { get; set; }

    }
}
