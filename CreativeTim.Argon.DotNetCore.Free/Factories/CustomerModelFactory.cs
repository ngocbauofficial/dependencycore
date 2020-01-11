using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Models.BaseListModel;
using CreativeTim.Argon.DotNetCore.Free.Models.Search;

namespace CreativeTim.Argon.DotNetCore.Free.Factories
{
    public partial class CustomerModelFactory : ICustomerModelFactory
    {


      public virtual  CustomerListModel PrepareNewsItemListModel(CustomerSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
