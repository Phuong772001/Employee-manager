using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.ContractAllowance
{
    public class UpdateContractAllowanceDTO
    {
        public int id { get; set; }
        public UpdateContractAllowance updateData { get; set; }
    }
    public class UpdateContractAllowance
    {
        public double? Money { get; set; }
    }
}
