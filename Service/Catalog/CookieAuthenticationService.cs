using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;

namespace Service.Catalog
{
    public partial class CookieAuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IUserService _customerService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private User _cachedCustomer;

        #endregion

        #region Ctor

        public CookieAuthenticationService(
            IUserService customerService,
            IHttpContextAccessor httpContextAccessor)
        {
          
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="isPersistent">Whether the authentication session is persisted across multiple requests</param>
        public virtual async void SignIn(User customer, bool isPersistent)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            //create claims for customer's username and email
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(customer.Username))
                claims.Add(new Claim(ClaimTypes.Name, customer.Username, ClaimValueTypes.String, AuthenticationDefaults.ClaimsIssuer));

            if (!string.IsNullOrEmpty(customer.Email))
                claims.Add(new Claim(ClaimTypes.Email, customer.Email, ClaimValueTypes.Email, AuthenticationDefaults.ClaimsIssuer));

            //create principal for the current authentication scheme
            var userIdentity = new ClaimsIdentity(claims, AuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            //set value indicating whether session is persisted and the time at which the authentication was issued
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow
            };

            //sign in
            await _httpContextAccessor.HttpContext.SignInAsync(AuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperties);

            //cache authenticated customer
            _cachedCustomer = customer;
        }

        /// <summary>
        /// Sign out
        /// </summary>
        public virtual async void SignOut()
        {
            //reset cached customer
            _cachedCustomer = null;

            //and sign out from the current authentication scheme
            await _httpContextAccessor.HttpContext.SignOutAsync(AuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        public virtual User GetAuthenticatedCustomer()
        {
            //whether there is a cached customer
            if (_cachedCustomer != null)
                return _cachedCustomer;

            //try to get authenticated user identity
            var authenticateResult = _httpContextAccessor.HttpContext.AuthenticateAsync(AuthenticationDefaults.AuthenticationScheme).Result;
            if (!authenticateResult.Succeeded)
                return null;

            User customer = null;
          
                //try to get customer by username
                var usernameClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Name
                    && claim.Issuer.Equals(AuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
                if (usernameClaim != null)
                    customer = _customerService.GetByUserName(usernameClaim.Value);
           
            //whether the found customer is available
            if (customer == null || !customer.Active || customer.Deleted )
                return null;

            //cache authenticated customer
            _cachedCustomer = customer;

            return _cachedCustomer;
        }

        #endregion
    }
}
