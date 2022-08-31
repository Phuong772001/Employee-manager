using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Welface
{
    public class WelfaceDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
