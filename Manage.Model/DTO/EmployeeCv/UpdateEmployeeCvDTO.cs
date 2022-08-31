using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeCv
{
    public class UpdateEmployeeCvDTO
    {
        public int id { get; set; }
        public UpdateEmployeeCv updateData { get; set; }
    }
    public class UpdateEmployeeCv
    {
        public int? EmployeeId { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public DateTime? BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string PerProvince { get; set; }
        public string PerDistrict { get; set; }
        public string PerWard { get; set; }
        public string PerAddress { get; set; }
        public string NavProvice { get; set; }
        public int? HospitalId { get; set; }
        public int? BankBrankId { get; set; }
        public int? BankId { get; set; }
        public string WorkEmail { get; set; }
        public string Email { get; set; }
        public string VisaPlace { get; set; }
        public DateTime? VisaDate { get; set; }
        public string Visa { get; set; }
        public string IdPlace { get; set; }
        public DateTime? IdDate { get; set; }
        public int? IdNo { get; set; }
        public string NavAddress { get; set; }
        public string NavWard { get; set; }
        public string NavDistrict { get; set; }
    }
}
