using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Catalog
{
    public partial class CalendarService : ICalendarService
    {
        private readonly IRepository<Calendar> _calendarReponsitory;

        public CalendarService(IRepository<Calendar> calendarReponsitory)
        {
            this._calendarReponsitory = calendarReponsitory;
        }
        public virtual IPagedList<Calendar> GetAll(int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            var query = _calendarReponsitory.Table;
            query = query.OrderByDescending(x => x.Id);

            var calendars = new PagedList<Calendar>(query, pageIndex, pageSize, getOnlyTotalCount);
            return calendars;
        }
        public virtual Calendar GetById(int id)
        {
            var calendars = _calendarReponsitory.GetById(id);
            return calendars;
        }
   

        public virtual void Insert(Calendar calendar)
        {
            _calendarReponsitory.Insert(calendar);

        }
        public virtual void Update(Calendar calendar)
        {
            _calendarReponsitory.Update(calendar);

        }
        public virtual void Delete(Calendar calendar)
        {
            _calendarReponsitory.Delete(calendar);

        }
        public virtual IList<Calendar> GetByIds(int[] Ids)
        {
            if (Ids == null || Ids.Length == 0)
                return new List<Calendar>();

            var query = from c in _calendarReponsitory.Table
                        where Ids.Contains(c.Id)
                        select c;
            var calendars = query.ToList();
            //sort by passed identifiers
            var sortedHostings = new List<Calendar>();
            foreach (var id in Ids)
            {
                var calendar = calendars.Find(x => x.Id == id);
                if (calendar != null)
                    sortedHostings.Add(calendar);
            }

            return sortedHostings;

        }


    }

}
