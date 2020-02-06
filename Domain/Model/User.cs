namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("User")]
    public partial class User : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Purchases = new HashSet<Purchase>();
        }
        public Guid Guid { get; set; }


        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


        public string Phone { get; set; }

        public bool? Gender { get; set; }

  
        public string Address { get; set; }


 
        public string Address1 { get; set; }


      
        public string Company { get; set; }



        public string TaxNumber { get; set; }


        public string LastIp { get; set; }

        public bool IsSystemAccount { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public DateTime? CannotLoginUntilDate { get; set; }


        public string Password { get; set; }


        public string PasswordSalt { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public int? RoleId { get; set; }

      
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }

        public virtual Role Role { get; set; }
    }
}
