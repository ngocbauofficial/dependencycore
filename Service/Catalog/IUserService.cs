using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Catalog
{
    public partial interface IUserService
    {
        IPagedList<User> GetAll(int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
        User GetByUserName(string username);
        User GetById(int Id);
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
        IList<User> GetByIds(int[] Ids);

    }
}
