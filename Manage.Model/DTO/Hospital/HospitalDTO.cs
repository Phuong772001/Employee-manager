using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Hospital
{
    public class HospitalDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        
    }
}
