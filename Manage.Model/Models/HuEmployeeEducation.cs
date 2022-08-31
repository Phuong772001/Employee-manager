using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_employee_education")]
    [Index(nameof(EmployeeId), Name = "IX_hu_employee_education_employee_id")]
    public partial class HuEmployeeEducation : IEntityBase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
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
        [Column("name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Column("note")]
        [StringLength(255)]
        public string Note { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("fisrt_date", TypeName = "datetime")]
        public DateTime? FisrtDate { get; set; }
        [Column("finsish_date", TypeName = "datetime")]
        public DateTime? FinsishDate { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(HuEmployee.HuEmployeeEducations))]
        public virtual HuEmployee Employee { get; set; }
    }
}
