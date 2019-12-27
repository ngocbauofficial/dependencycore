namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  


    public partial class PurchaseModel : BaseModelEntity
    {


        public int CustomerId { get; set; }

        [StringLength(1000)]
        public string DomainName { get; set; }

        public int? HostingId { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime? RegistedDate { get; set; }

        public DateTime? ContractRegisterDate { get; set; }

        public int? Status { get; set; }

        public virtual HostingModel Hosting { get; set; }

        public virtual UserModel User { get; set; }
    }
}
