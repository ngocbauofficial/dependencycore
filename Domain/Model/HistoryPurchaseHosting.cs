namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("HistoryPurchaseHosting")]
    public partial class HistoryPurchaseHosting : BaseEntity
    {


        public int? HostingId { get; set; }

        public int? Price { get; set; }

        public DateTime? RegisterAndUpdateDate { get; set; }

        public int? NumberMonth { get; set; }

        public virtual Hosting Hosting { get; set; }
    }
}
