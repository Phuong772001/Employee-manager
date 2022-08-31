using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_district")]
    [Index(nameof(ProvinceId), Name = "IX_hu_district_province_id")]
    public partial class HuDistrict : IEntityBase
    {
        public HuDistrict()
        {
            HuWards = new HashSet<HuWard>();
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
        [Column("province_id")]
        public int? ProvinceId { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty(nameof(HuProvince.HuDistricts))]
        public virtual HuProvince Province { get; set; }
        [InverseProperty(nameof(HuWard.Distric))]
        public virtual ICollection<HuWard> HuWards { get; set; }
    }
}
