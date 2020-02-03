using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Catalog
{
  public partial class HostingService : IHostingService
    {
        private readonly IRepository<Hosting> _hostingReponsitory;

        public HostingService(IRepository<Hosting> hostingReponsitory)
        {
            this._hostingReponsitory = hostingReponsitory;
        }
        public virtual IPagedList<Hosting> GetAll(int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            var query = _hostingReponsitory.Table;
            query = query.OrderByDescending(x => x.Id);

            var hostings = new PagedList<Hosting>(query, pageIndex, pageSize, getOnlyTotalCount);
            return hostings;
        }
        public virtual Hosting GetHostingById(int id)
        {
            var hosting = _hostingReponsitory.GetById(id);
            return hosting;
        }
        public virtual Hosting GetHostingByUserName(string username)
        {
            var query = from a in _hostingReponsitory.Table where a.UserName == username select a;

            var hosting = query.FirstOrDefault();
            return hosting;
        }
     
        public virtual void Insert(Hosting hosting)
        {
            _hostingReponsitory.Insert(hosting);

        }
        public virtual void Update(Hosting hosting)
        {
            _hostingReponsitory.Update(hosting);

        }
        public virtual void Delete(Hosting hosting)
        {
            _hostingReponsitory.Delete(hosting);

        }
        public virtual IList<Hosting> GetByIds(int[] Ids)
        {
            if (Ids == null || Ids.Length == 0)
                return new List<Hosting>();

            var query = from c in _hostingReponsitory.Table
                        where Ids.Contains(c.Id) 
                        select c;
            var hostings = query.ToList();
            //sort by passed identifiers
            var sortedHostings = new List<Hosting>();
            foreach (var id in Ids)
            {
                var hosting = hostings.Find(x => x.Id == id);
                if (hosting != null)
                    sortedHostings.Add(hosting);
            }

            return sortedHostings;

        }


    }

}
