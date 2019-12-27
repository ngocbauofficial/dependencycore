using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public abstract partial class BaseModelEntity : BaseModel
    {
     
            /// <summary>
            /// Gets or sets the entity identifier
            /// </summary>
            public int Id { get; set; }
  
    }
}
