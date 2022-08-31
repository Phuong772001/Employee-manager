using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.ContractAllowance
{
    public class ContractAllowanceDTO
    {
        [Required]
        public string Allwance { get; set; }
        [Required]
        public double? Money { get; set; }
        [Required]
        public string Contract { get; set; }
    }
    public class ContractAllowance
    {
        public int AllwanceId { get; set; }
        public int ContractId { get; set; }
        public string Allwance { get; set; }
        public double? Money { get; set; }
        public string Contract { get; set; }

    }
}
