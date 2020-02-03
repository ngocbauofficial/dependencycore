using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Catalog
{
    public partial interface IAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="isPersistent">Whether the authentication session is persisted across multiple requests</param>
        void SignIn(User customer, bool isPersistent);

        /// <summary>
        /// Sign out
        /// </summary>
        void SignOut();

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        User GetAuthenticatedCustomer();
    }
}
