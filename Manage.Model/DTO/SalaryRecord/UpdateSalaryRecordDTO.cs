using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.SalaryRecord
{
    public class UpdateSalaryRecordDTO
    {
        public int id { get; set; }
        public UpdateSalaryRecord updateData { get; set; }
    }
    public class UpdateSalaryRecord
    {
        public int? EmployeeId { get; set; }
        public int? ContracId { get; set; }
        public int? ContractAllwanceId { get; set; }
        public int? ContractWelfaceId { get; set; }
        public double? Money { get; set; }
    }
}
