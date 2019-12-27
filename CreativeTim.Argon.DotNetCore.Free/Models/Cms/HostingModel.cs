namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class HostingModel : BaseModelEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HostingModel()
        {
            HistoryPurchaseHostings = new HashSet<HistoryPurchaseHostingModel>();
            Purchases = new HashSet<PurchaseModel>();
        }



        [StringLength(1000)]
        public string HostingIp { get; set; }

        [StringLength(1000)]
        public string HostingName { get; set; }

        [StringLength(1000)]
        public string LinkLogin { get; set; }

        [StringLength(1000)]
        public string UserName { get; set; }

        [StringLength(1000)]
        public string Password { get; set; }

        [StringLength(1000)]
        public string Vendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryPurchaseHostingModel> HistoryPurchaseHostings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseModel> Purchases { get; set; }
    }
}
