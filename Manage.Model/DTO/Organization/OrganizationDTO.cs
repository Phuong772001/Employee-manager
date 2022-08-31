using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Organization
{
    public class OrganizationDTO
    {
        [Required]
        public string Name { get; set; }
        public string? ParentName { get; set; }
    }
}
