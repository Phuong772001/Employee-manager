using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OrgTitle
{
    public class UpdateOrgTitleDTO
    {
        public int id { get; set; }
        public UpdateOrgTitle updateData { get; set; }
    }
    public class UpdateOrgTitle
    {
        public string Org { get; set; }
        public string Title { get; set; }
    }
}
