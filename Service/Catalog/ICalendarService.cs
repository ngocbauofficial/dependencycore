using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Catalog
{

    public interface ICalendarService
    {
        IPagedList<Calendar> GetAll(int pageindex = 0, int pagesize = int.MaxValue, bool getOnlyTotalCount = false);
        Calendar GetById(int id);
        void Insert(Calendar hosting);
        void Update(Calendar hosting);
        void Delete(Calendar hosting);
        IList<Calendar> GetByIds(int[] Ids);
    }
}
