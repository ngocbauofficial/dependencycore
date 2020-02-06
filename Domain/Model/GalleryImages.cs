using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{

        [Table("GalleryImages")]
        public partial class GalleryImages : BaseEntity
        {
            public string Url { get; set; }
        public string Alt { get; set; }
        public int FriendId { get; set; }
    }
}
