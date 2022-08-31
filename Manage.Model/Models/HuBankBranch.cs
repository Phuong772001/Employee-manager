using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_bank_branch")]
    [Index(nameof(BankId), Name = "IX_hu_bank_branch_bank_id")]
    public partial class HuBankBranch :IEntityBase
    {
        public HuBankBranch()
        {
            HuEmployeeCvs = new HashSet<HuEmployeeCv>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Column("bank_id")]
        public int BankId { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }
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

        [ForeignKey(nameof(BankId))]
        [InverseProperty(nameof(HuBank.HuBankBranches))]
        public virtual HuBank Bank { get; set; }
        [InverseProperty(nameof(HuEmployeeCv.BankBrank))]
        public virtual ICollection<HuEmployeeCv> HuEmployeeCvs { get; set; }
    }
}
