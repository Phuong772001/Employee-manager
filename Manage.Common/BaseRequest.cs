using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public class BaseRequest
    {
        ////Define the variable name in the header that stores the correlation-id
            //public Guid crid { get; set; }
        //// token login
            //public string token { get; set; }
        //// info user
            //public BaseUser baseUser { get; set; }
        //// page number
        public int pageNum { get; set; }
        //// page size
        public int pageSize { get; set; }
        //// object
            //public T item { get; set; }
        //// object filter
            public string? keyworks { get; set; }
        //// list object
            //public List<T> items { get; set; }
    }
}
