namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Friend")]
    public partial class Friend : BaseEntity
    {
     

        public int UserId { get; set; }

      
        public string Name { get; set; }

      
        public string Phone { get; set; }

  
        public string Address { get; set; }


        public string FacebookLink { get; set; }

     
        public string Zalo { get; set; }

   
        public string Avatar { get; set; }

        public int GalleryImageId { get; set; }
    }
}
