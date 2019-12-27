namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

  public partial class FriendModel : BaseModelEntity
    {
  

        public int UserId { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Phone { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string FacebookLink { get; set; }

        [StringLength(1000)]
        public string Zalo { get; set; }

        [StringLength(1000)]
        public string Avatar { get; set; }
    }
}
