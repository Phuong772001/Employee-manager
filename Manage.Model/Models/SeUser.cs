using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manage.Model.Base;


#nullable disable

namespace Manage.Model.Models
{
    [Table("Se_User")]
    public partial class SeUser : IEntityBase
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
        public string Username { get; set; }
        public string Password { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public DateTime expired_time { get; set; }
        public string Role { get; set; }
        public string Activeflg { get; set; }
    }
}
