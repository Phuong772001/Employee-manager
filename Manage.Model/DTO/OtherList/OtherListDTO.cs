using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OtherList
{
    public class OtherListDTO
    {
        [Required]
        public string TypeName { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
