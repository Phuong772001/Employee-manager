using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_salary_records")]
    [Index(nameof(ContracId), Name = "IX_hu_salary_records_contrac_id")]
    [Index(nameof(ContractAllwanceId), Name = "IX_hu_salary_records_contract_allwance_id")]
    [Index(nameof(ContractWelfaceId), Name = "IX_hu_salary_records_contract_welface_id")]
    [Index(nameof(EmployeeId), Name = "IX_hu_salary_records_employee_id")]
    public partial class HuSalaryRecord : IEntityBase
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
        public int? EmployeeId { get; set; }
        [Column("contrac_id")]
        public int? ContracId { get; set; }
        [Column("contract_allwance_id")]
        public int? ContractAllwanceId { get; set; }
        [Column("contract_welface_id")]
        public int? ContractWelfaceId { get; set; }
        [Column("money")]
        public double? Money { get; set; }

        [ForeignKey(nameof(ContracId))]
        [InverseProperty(nameof(HuContract.HuSalaryRecords))]
        public virtual HuContract Contrac { get; set; }
        [ForeignKey(nameof(ContractAllwanceId))]
        [InverseProperty(nameof(HuContractAllowance.HuSalaryRecords))]
        public virtual HuContractAllowance ContractAllwance { get; set; }
        [ForeignKey(nameof(ContractWelfaceId))]
        [InverseProperty(nameof(HuWelface.HuSalaryRecords))]
        public virtual HuWelface ContractWelface { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(HuEmployee.HuSalaryRecords))]
        public virtual HuEmployee Employee { get; set; }
        
    }
}
