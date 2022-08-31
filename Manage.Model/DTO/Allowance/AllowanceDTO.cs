using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Allowance
{
    public class AllowanceDTO
    {   
        [Required]
        public string Name { get; set; }
    }
}
