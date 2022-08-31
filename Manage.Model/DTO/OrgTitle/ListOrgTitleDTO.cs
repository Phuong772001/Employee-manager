using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OrgTitle
{
    public class ListOrgTitle
    {
        public int Id { get; set; }
        public string Org { get; set; }
        public int OrgId { get; set; }
        public string Title { get; set; }
        public int TitleId { get; set; }
        public string Code { get; set; }
    }
    public class ListOrgTitleDTO
    {
        public int Id { get; set; }
        public string Org { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
