using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.BankBranch
{
    public class BankBranchDTO
    {
        [Required]
        public string BankName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
