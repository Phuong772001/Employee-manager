using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.Ward
{
    public class WardDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DistrictName { get; set; }
    }
}
