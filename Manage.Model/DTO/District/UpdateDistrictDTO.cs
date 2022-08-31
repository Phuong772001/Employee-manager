using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.District
{
   public class UpdateDistrictDTO
    {
        public int Id { get; set; }
        public UpdateDistrict updateData { get; set; }
    }
   public class UpdateDistrict
    {
        public string Name { get; set; }
        public string ProvinceName { get; set; }
    }
}
