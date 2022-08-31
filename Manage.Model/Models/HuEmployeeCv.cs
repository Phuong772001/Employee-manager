using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_employee_cv")]
    public partial class HuEmployeeCv : IEntityBase
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
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("gender")]
        [StringLength(50)]
        public string Gender { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("birth_day", TypeName = "datetime")]
        public DateTime? BirthDay { get; set; }
        [Column("birth_place")]
        [StringLength(50)]
        public string BirthPlace { get; set; }
        [Column("marital_status")]
        [StringLength(50)]
        public string MaritalStatus { get; set; }
        [Column("religion")]
        [StringLength(50)]
        public string Religion { get; set; }
        [Column("nation_id")]
        public int? NationId { get; set; }
        [Column("per_province")]
        public string PerProvince { get; set; }
        [Column("per_district")]
        public string PerDistrict { get; set; }
        [Column("per_ward")]
        public string PerWard { get; set; }
        [Column("per_address")]
        public string PerAddress { get; set; }
        [Column("nav-provice")]
        public string NavProvice { get; set; }
        [Column("nav_district")]
        public string NavDistrict { get; set; }
        [Column("nav_ward")]
        public string NavWard { get; set; }
        [Column("nav_address")]
        public string NavAddress { get; set; }
        [Column("id_no")]
        public int? IdNo { get; set; }
        [Column("id_date", TypeName = "datetime")]
        public DateTime? IdDate { get; set; }
        [Column("id_place")]
        public string IdPlace { get; set; }
        [Column("visa")]
        public string Visa { get; set; }
        [Column("visa_date", TypeName = "datetime")]
        public DateTime? VisaDate { get; set; }
        [Column("visa_place")]
        public string VisaPlace { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("work_email")]
        public string WorkEmail { get; set; }
        [Column("bank_id")]
        public int? BankId { get; set; }
        [Column("bank_brank_id")]
        public int? BankBrankId { get; set; }
        [Column("hospital_id")]
        public int? HospitalId { get; set; }

        [ForeignKey(nameof(BankId))]
        [InverseProperty(nameof(HuBank.HuEmployeeCvs))]
        public virtual HuBank Bank { get; set; }
        [ForeignKey(nameof(BankBrankId))]
        [InverseProperty(nameof(HuBankBranch.HuEmployeeCvs))]
        public virtual HuBankBranch BankBrank { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(HuEmployee.HuEmployeeCvs))]
        public virtual HuEmployee Employee { get; set; }
        [ForeignKey(nameof(HospitalId))]
        [InverseProperty(nameof(HuHospital.HuEmployeeCvs))]
        public virtual HuHospital Hospital { get; set; }
        [ForeignKey(nameof(NationId))]
        [InverseProperty(nameof(HuNation.HuEmployeeCvs))]
        public virtual HuNation Nation { get; set; }
        public string Code { get; set ; }
    }
}
