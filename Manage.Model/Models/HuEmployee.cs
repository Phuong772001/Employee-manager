using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_employee")]
    [Index(nameof(ContractId), Name = "IX_hu_employee_contract_id")]
    [Index(nameof(OrgId), Name = "IX_hu_employee_org_id")]
    [Index(nameof(TitleId), Name = "IX_hu_employee_title_id")]
    public partial class HuEmployee : IEntityBase
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
        [StringLength(255)]
        public string EmployeeCode { get; set; }
        [Column("first_name")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("full_name")]
        [StringLength(255)]
        public string FullName { get; set; }
        [Column("org_id")]
        public int? OrgId { get; set; }
        [Column("join_date", TypeName = "datetime")]
        public DateTime? JoinDate { get; set; }
        [Column("work_status")]
        public bool? WorkStatus { get; set; }
        [Column("contract_id")]
        public int? ContractId { get; set; }
        [Column("title_id")]
        public int? TitleId { get; set; }
        [Column("working_id")]
        public int? WorkingId { get; set; }
        [Column("direct_manager")]
        [StringLength(255)]
        public string DirectManager { get; set; }
        [Column("itime_id")]
        public int? ItimeId { get; set; }
        [Column("last_working_id")]
        public int? LastWorkingId { get; set; }
        [Column("last_working_day", TypeName = "datetime")]
        public DateTime? LastWorkingDay { get; set; }

        [ForeignKey(nameof(ContractId))]
        [InverseProperty(nameof(HuContract.HuEmployees))]
        public virtual HuContract Contract { get; set; }
        [ForeignKey(nameof(OrgId))]
        [InverseProperty(nameof(HuOrgTitle.HuEmployees))]
        public virtual HuOrgTitle Org { get; set; }
        [ForeignKey(nameof(OrgId))]
        [InverseProperty(nameof(HuOrganization.HuEmployees))]
        public virtual HuOrganization OrgNavigation { get; set; }
        [ForeignKey(nameof(TitleId))]
        [InverseProperty(nameof(HuTitle.HuEmployees))]
        public virtual HuTitle Title { get; set; }
        [InverseProperty(nameof(HuEmployeeCv.Employee))]
        public virtual HuEmployeeCv HuEmployeeCvs { get; set; }
        [InverseProperty(nameof(HuEmployeeEducation.Employee))]
        public virtual HuEmployeeEducation HuEmployeeEducations { get; set; }
        [InverseProperty(nameof(HuEmployeeFamily.Employee))]
        public virtual HuEmployeeFamily HuFamilies { get; set; }
        [InverseProperty(nameof(HuSalaryRecord.Employee))]
        public virtual HuSalaryRecord HuSalaryRecords { get; set; }
        [InverseProperty(nameof(HuSchool.Employee))]
        public virtual HuSchool HuShools { get; set; }
    }
}
