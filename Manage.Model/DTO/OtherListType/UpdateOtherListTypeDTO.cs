using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.OtherListType
{
    public class UpdateOtherListTypeDTO
    {
        public int Id { get; set; }
        public UpdateOtherListType updateData { get; set; }
    }
    public class UpdateOtherListType
    {
        public string Name { get; set; }
       
    }
}
