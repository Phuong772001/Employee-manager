using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.DTO.School
{
    public class ListSchoolDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? YearGra { get; set; }
        public string Schools { get; set; }
        public string Certificate { get; set; }
        public DateTime? CertificateFromDate { get; set; }
        public DateTime? CertificateTodate { get; set; }
        public string TrainForm { get; set; }

    }
}
