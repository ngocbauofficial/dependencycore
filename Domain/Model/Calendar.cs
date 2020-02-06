using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{

        [Table("Calendar")]
        public partial class Calendar : BaseEntity
        {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int IsUser { get; set; }
    }
}
