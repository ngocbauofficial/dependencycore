using CreativeTim.Argon.DotNetCore.Free.Models.BaseListModel;
using CreativeTim.Argon.DotNetCore.Free.Models.Search;


namespace CreativeTim.Argon.DotNetCore.Free.Factories
{
    public partial interface ICustomerModelFactory
    {
        CustomerListModel PrepareNewsItemListModel(CustomerSearchModel searchModel);
    }
}
