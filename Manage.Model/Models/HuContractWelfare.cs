using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_contractual_benefits")]
    [Index(nameof(ContractId), Name = "IX_hu_contractual_benefits_contract_id")]
    [Index(nameof(WelfaceId), Name = "IX_hu_contractual_benefits_welface_id")]
    public partial class HuContractWelface : IEntityBase
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
        [Column("contract_id")]
        public int? ContractId { get; set; }
        [Column("welface_id")]
        public int? WelfaceId { get; set; }
        [Column("money")]
        public double? Money { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }

        [ForeignKey(nameof(ContractId))]
        [InverseProperty(nameof(HuContract.HuContractWelfaces))]
        public virtual HuContract Contract { get; set; }
        [ForeignKey(nameof(WelfaceId))]
        [InverseProperty(nameof(HuWelface.HuContractWelfaces))]
        public virtual HuWelface Welface { get; set; }
    }
}
