using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public class BaseResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public object item { get; set; }
        //public List<object> items { get; set; }
    }
}
