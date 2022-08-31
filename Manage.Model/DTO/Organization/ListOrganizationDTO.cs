using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Organization
{
    public class ListOrganization
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Parent { get; set; }
        public int? OrderNumber { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }

    }
    public class ListOrganizationDTO
    {       
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public int? OrderNumber { get; set; }
    }
}
