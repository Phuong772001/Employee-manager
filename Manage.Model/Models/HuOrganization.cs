using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_organization")]
    public partial class HuOrganization : IEntityBase
    {
        public HuOrganization()
        {
            HuEmployees = new HashSet<HuEmployee>();
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
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("order_number")]
        public int? OrderNumber { get; set; }
        [Column("activeflg")]
        public string Activeflg { get; set; }

        [InverseProperty(nameof(HuEmployee.OrgNavigation))]
        public virtual ICollection<HuEmployee> HuEmployees { get; set; }
    }
}
