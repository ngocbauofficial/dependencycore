using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Catalog
{
    public partial class UserService : IUserService
    {
        private readonly IRepository<User> _userReponsitory;
        public UserService(IRepository<User> userReponsitory)
        {
            this._userReponsitory = userReponsitory;
        }
        public virtual IPagedList<User> GetAll(int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            var query = _userReponsitory.Table;
            query = query.OrderByDescending(x => x.CreatedOn);

           var users = new PagedList<User>(query, pageIndex, pageSize, getOnlyTotalCount);
            return users;
        }
    
        public virtual IEnumerable<User> GetAllTest()
        {
            var query = _userReponsitory.Table;
            query = query.OrderByDescending(x => x.CreatedOn);
         var list=   query.ToList();
            return list;
        }
        public virtual User GetByUserName(string username)
        {
            var query = from a in _userReponsitory.Table where a.Username == username select a;

            var user = query.FirstOrDefault();
            return user;
        }
        public virtual User GetById(int id)
        {
            var user = _userReponsitory.GetById(id);
            return user;
        }
        public virtual void Insert(User user)
        {
            _userReponsitory.Insert(user);
    
        }
        public virtual void Update(User user)
        {
             _userReponsitory.Update(user);
            
        }
        public virtual void Delete(User user)
        {
            _userReponsitory.Delete(user);

        }
        public virtual IList<User> GetByIds(int[] Ids)
        {
            if (Ids == null || Ids.Length == 0)
                return new List<User>();

            var query = from c in _userReponsitory.Table
                        where Ids.Contains(c.Id) && !c.Deleted
                        select c;
            var customers = query.ToList();
            //sort by passed identifiers
            var sortedCustomers = new List<User>();
            foreach (var id in Ids)
            {
                var customer = customers.Find(x => x.Id == id);
                if (customer != null)
                    sortedCustomers.Add(customer);
            }

            return sortedCustomers;

        }
    }
}
