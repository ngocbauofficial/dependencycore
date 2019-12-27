namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

 
    public partial class HistoryPurchaseHostingModel : BaseModelEntity
    {


        public int? HostingId { get; set; }

        public int? Price { get; set; }

        public DateTime? RegisterAndUpdateDate { get; set; }

        public int? NumberMonth { get; set; }

        public virtual HostingModel Hosting { get; set; }
    }
}
