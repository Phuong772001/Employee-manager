using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.User
{
    public class TokenDecode
    {
        public string username { get; set; }
        public string role { get; set; }
        public long exp { get; set; }
    }
}
