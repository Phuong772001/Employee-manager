using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Allowance
{
    public class UpdateAllowanceDTO
    {
        public int id { get; set; }
        public UpdateDataAllowance updateData { get; set; }
    }
    public class UpdateDataAllowance
    {
        public string Name { get; set; }
    }
}
