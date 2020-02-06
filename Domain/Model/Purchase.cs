namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    [Table("Purchase")]
    public partial class Purchase : BaseEntity
    {
        

        public int CustomerId { get; set; }


        public string DomainName { get; set; }

        public int? HostingId { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime? RegistedDate { get; set; }

        public DateTime? ContractRegisterDate { get; set; }

        public int? Status { get; set; }

        public virtual Hosting Hosting { get; set; }

        public virtual User User { get; set; }
    }
}
