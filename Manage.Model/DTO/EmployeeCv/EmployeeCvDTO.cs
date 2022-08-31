using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeCv
{
    public class EmployeeCvDTO
    {
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public DateTime? BirthDay { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string PerProvince { get; set; }
        [Required]
        public string PerDistrict { get; set; }
        [Required]
        public string PerWard { get; set; }
        [Required]
        public string PerAddress { get; set; }
        [Required]
        public string NavProvice { get; set; }
        [Required]
        public int? HospitalId { get; set; }
        [Required]
        public int? BankBrankId { get; set; }
        [Required]
        public int? BankId { get; set; }
        [Required]
        public string WorkEmail { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string VisaPlace { get; set; }
        [Required]
        public DateTime? VisaDate { get; set; }
        [Required]
        public string Visa { get; set; }
        [Required]
        public string IdPlace { get; set; }
        [Required]
        public DateTime? IdDate { get; set; }
        [Required]
        public int? IdNo { get; set; }
        [Required]
        public string NavAddress { get; set; }
        [Required]
        public string NavWard { get; set; }
        [Required]
        public string NavDistrict { get; set; }

    }
}
