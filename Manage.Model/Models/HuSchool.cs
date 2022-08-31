using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_shools")]
    public partial class HuSchool : IEntityBase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("from_date", TypeName = "datetime")]
        public DateTime? FromDate { get; set; }
        [Column("to_date", TypeName = "datetime")]
        public DateTime? ToDate { get; set; }
        [Column("year_gra")]
        public int? YearGra { get; set; }
        [Column("schools")]
        public string Schools { get; set; }
        [Column("certificate")]
        public string Certificate { get; set; }
        [Column("certificate_from_date", TypeName = "datetime")]
        public DateTime? CertificateFromDate { get; set; }
        [Column("certificate_todate", TypeName = "datetime")]
        public DateTime? CertificateTodate { get; set; }
        [Column("train_form")]
        public string TrainForm { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("created_time", TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [Column("last_updated_by")]
        public string LastUpdatedBy { get; set; }
        [Column("last_update_time", TypeName = "datetime")]
        public DateTime? LastUpdateTime { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(HuEmployee.HuShools))]
        public virtual HuEmployee Employee { get; set; }
        public string Code { get ; set  ; }
    }
}
