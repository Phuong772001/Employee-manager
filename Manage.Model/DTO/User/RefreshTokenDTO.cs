using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.User
{
    public class RefreshTokenDTO
    {
        public string username { get; set; }
        public string refresh_token { get; set; }
        //public long exp { get; set; }
    }
}
