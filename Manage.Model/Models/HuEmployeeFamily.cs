using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_employee_family")]
    [Index(nameof(EmployeeId), Name = "IX_hu_family_employee_id")]
    public partial class HuEmployeeFamily : IEntityBase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("created_by")]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column("created_time", TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [Column("last_updated_by")]
        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
        [Column("last_update_time", TypeName = "datetime")]
        public DateTime? LastUpdateTime { get; set; }
        [Column("full_name")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("relation")]
        public string Relation { get; set; }
        [Column("id_no")]
        public int? IdNo { get; set; }
        [Column("is_deduct")]
        public string IsDeduct { get; set; }
        [Column("deduct_from", TypeName = "datetime")]
        public DateTime? DeductFrom { get; set; }
        [Column("deduct_to", TypeName = "datetime")]
        public DateTime? DeductTo { get; set; }
        [Column("remark")]
        public string Remark { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(HuEmployee.HuFamilies))]
        public virtual HuEmployee Employee { get; set; }
        public string Code { get; set; }
    }
}
