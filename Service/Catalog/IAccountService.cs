using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Catalog
{
   
        public partial interface IAccountService
          {
            int GetLogin(string username,string password);
        }
    
}
