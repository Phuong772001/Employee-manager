using System;
using System.ComponentModel.DataAnnotations;

namespace Manage.Model.DTO.District
{
    public class DistrictDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProvinceName { get; set; }
    }
}
