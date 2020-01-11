
using System.Collections.Generic;


namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public abstract partial class BasePagedListModel<T> : BaseModel, IPagedModel<T> where T : BaseModel
    {
        /// <summary>
        /// Gets or sets data records
        /// </summary>
        public IEnumerable<T> data { get; set; }

        /// <summary>
        /// Gets or sets draw
        /// </summary>
        public string draw { get; set; }

        /// <summary>
        /// Gets or sets a number of filtered data records
        /// </summary>
        public int recordsFiltered { get; set; }

        /// <summary>
        /// Gets or sets a number of total data records
        /// </summary>
        public int recordsTotal { get; set; }

        //TODO: remove after moving to DataTables grids
        public int total { get; set; }
    }
}
