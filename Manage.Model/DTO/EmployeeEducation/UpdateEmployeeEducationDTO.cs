using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeEducation
{
    public class UpdateEmployeeEducationDTO
    {
        public int id { get; set; }
        public UpdateEmployeeEducation updateData { get; set; }
    }
    public class UpdateEmployeeEducation
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? FisrtDate { get; set; }
        public DateTime? FinsishDate { get; set; }
        public string Activeflg { get; set; }
    }
}
