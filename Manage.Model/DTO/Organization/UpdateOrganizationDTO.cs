using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.Organization
{
    public class UpdateOrganizationDTO
    {
        public int id { get; set; }
        public UpdateOrganization updateData { get; set; }
    }
    public class UpdateOrganization
    {
        public string Name { get; set; }
        public string ParentName { get; set; }
    }
}
