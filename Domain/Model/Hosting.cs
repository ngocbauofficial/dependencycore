namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Hosting")]
    public partial class Hosting : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hosting()
        {
            HistoryPurchaseHostings = new HashSet<HistoryPurchaseHosting>();
            Purchases = new HashSet<Purchase>();
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
        public virtual ICollection<HistoryPurchaseHosting> HistoryPurchaseHostings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
