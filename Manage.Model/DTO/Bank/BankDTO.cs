using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Bank
{
    public class BankDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
