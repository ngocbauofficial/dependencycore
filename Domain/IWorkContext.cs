using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        User CurrentUser { get; set; }

        /// <summary>
        /// Gets the original customer (in case the current one is impersonated)
        /// </summary>
    

        /// <summary>
        /// Gets or sets value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
