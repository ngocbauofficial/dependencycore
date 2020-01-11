namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class UserModel : BaseModelEntity 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserModel()
        {
            Purchases = new HashSet<PurchaseModel>();
        }

  

        public Guid Guid { get; set; }

        [StringLength(1000)]
        public string Username { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Phone { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string LastIp { get; set; }

        public bool IsSystemAccount { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime? CannotLoginUntilDate { get; set; }

        [StringLength(1000)]
        public string Password { get; set; }

        [StringLength(1000)]
        public string PasswordSalt { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public int? RoleId { get; set; }

        [StringLength(1000)]
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseModel> Purchases { get; set; }

        public virtual RoleModel Role { get; set; }

     
    }
}
