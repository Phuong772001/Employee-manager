using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_province")]
    [Index(nameof(NationId), Name = "IX_hu_province_nation_id")]
    public partial class HuProvince : IEntityBase
    {
        public HuProvince()
        {
            HuDistricts = new HashSet<HuDistrict>();
        }

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
        [StringLength(255)]
        public string Name { get; set; }
        [Column("nation_id")]
        public int? NationId { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }

        [ForeignKey(nameof(NationId))]
        [InverseProperty(nameof(HuNation.HuProvinces))]//HuProvinces
        public virtual HuNation Nation { get; set; }
        [InverseProperty(nameof(HuDistrict.Province))]
        public virtual ICollection<HuDistrict> HuDistricts { get; set; }
    }
}
