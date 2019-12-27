namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class PermissionRecordModel : BaseModelEntity
    {
     

        public string Name { get; set; }

        [StringLength(1000)]
        public string SystemName { get; set; }

        [StringLength(1000)]
        public string Category { get; set; }

        public virtual RoleModel Role { get; set; }
    }
}
