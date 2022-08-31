using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Contract
{
    public class ContractDTO
    {
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        [Required]
        public int? NumberOfMonth { get; set; }
        [Required]
        public double? Money { get; set; }
       
    }
}
