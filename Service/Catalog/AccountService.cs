using Domain;
using Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Service.Catalog
{

        public partial class AccountService : IAccountService
    {
            private readonly IRepository<User> _userReponsitory;
            public AccountService(IRepository<User> userReponsitory)
            {
                this._userReponsitory = userReponsitory;
            }
        public int GetLogin(string userName,string password)
        {
            var query = from a in _userReponsitory.Table where a.Username == userName && a.Password == password select a ;
            var user = query.Count();
            if (user>0)
            {
                return 1;
            }
            return 0;
        }


        }
    
}
