using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public abstract partial class BaseSearchModel : BaseModel
    {
        #region Ctor

        public BaseSearchModel()
        {
            //set the default values
            Length = 10;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a page number
        /// </summary>
        public int Page => (Start / Length) + 1;

        /// <summary>
        /// Gets a page size
        /// </summary>
        public int PageSize => Length;

        /// <summary>
        /// Gets or sets a comma-separated list of available page sizes
        /// </summary>
        public string AvailablePageSizes { get; set; }

        /// <summary>
        /// Gets or sets draw. Draw counter. This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence).
        /// </summary>
        public string Draw { get; set; }

        /// <summary>
        /// Gets or sets skiping number of rows count. Paging first record indicator.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets paging length. Number of records that the table can display in the current draw. 
        /// </summary>
        public int Length { get; set; }

        #endregion

     
    }
}
