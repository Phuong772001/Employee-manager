using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OrgTitle
{
    public class OrgTitleDTO
    {
        [Required]
        public string Org { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
