using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models.Search
{
    public class CustomerSearchModel:BaseSearchModel
    {
        #region Ctor

        public CustomerSearchModel()
        {
            SelectedCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();
        }

        #endregion

        #region Properties


        public IList<int> SelectedCustomerRoleIds { get; set; }

        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

    
        public string SearchEmail { get; set; }

        public string SearchUsername { get; set; }

        public string SearchName { get; set; }

        public string SearchCompany { get; set; }


        public string SearchPhone { get; set; }

        public string PhoneEnabled { get; set; }

    
        public string SearchIpAddress { get; set; }



        #endregion
    }
}
