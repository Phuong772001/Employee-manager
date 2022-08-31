using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Nation
{
    public class NationDTO
    {
        [Required]
        public string Name { get; set; }
        
    }
}
