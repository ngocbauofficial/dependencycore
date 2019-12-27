using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Factories
{
    public partial interface ICustomerModelFactory
    {
        NewsItemListModel PrepareNewsItemListModel(NewsItemSearchModel searchModel);
    }
}
