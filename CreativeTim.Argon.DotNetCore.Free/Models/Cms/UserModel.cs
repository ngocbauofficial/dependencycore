namespace CreativeTim.Argon.DotNetCore.Free.Models.Cms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class UserModel : BaseModelEntity 
    {

  

        public Guid Guid { get; set; }

        [StringLength(1000)]
        public string Username { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Phone { get; set; }
        public bool? Gender { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1000)]
        public string Address1 { get; set; }


        [StringLength(1000)]
        public string Company { get; set; }


        [StringLength(1000)]
        public string TaxNumber { get; set; }

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


     
    }
}
