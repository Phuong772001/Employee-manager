using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;


#nullable disable

namespace Manage.Model.Models
{
    [Table("hu_title")]
    public partial class HuTitle : IEntityBase
    {
        public HuTitle()
        {
            HuEmployees = new HashSet<HuEmployee>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("group_id")]
        [StringLength(255)]
        public int? GroupId { get; set; }
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
        

        [InverseProperty(nameof(HuEmployee.Title))]
        public virtual ICollection<HuEmployee> HuEmployees { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty(nameof(OtherList.Title))]
        public virtual OtherList OtherLists { get; set; }
        
    }
}
