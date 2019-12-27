namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("PermissionRecord")]
    public partial class PermissionRecord : BaseEntity
    {
      

        public string Name { get; set; }

        [StringLength(1000)]
        public string SystemName { get; set; }

        [StringLength(1000)]
        public string Category { get; set; }

        public virtual Role Role { get; set; }
    }
}
