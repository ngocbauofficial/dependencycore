using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Catalog
{
    public interface IHostingService
    {
        IPagedList<Hosting> GetAll(int pageindex = 0, int pagesize = int.MaxValue, bool getOnlyTotalCount = false);
        Hosting GetHostingById(int id);
        Hosting GetHostingByUserName(string username);
        void Insert(Hosting hosting);
        void Update(Hosting hosting);
        void Delete(Hosting hosting);
        IList<Hosting> GetByIds(int[] Ids);
    }
}
