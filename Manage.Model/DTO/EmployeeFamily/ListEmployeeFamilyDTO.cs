using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.EmployeeFamily
{
    public class ListEmployeeFamilyDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Relation { get; set; }
        public int? IdNo { get; set; }
        public string IsDeduct { get; set; }
        public DateTime? DeductFrom { get; set; }
        public DateTime? DeductTo { get; set; }
        public string Remark { get; set; }
    }
}
