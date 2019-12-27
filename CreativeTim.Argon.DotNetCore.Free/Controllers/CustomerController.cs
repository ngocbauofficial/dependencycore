using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class CustomerController : BaseController
    {
        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
           

            //prepare model
            var model = _customerModelFactory.PrepareCustomerSearchModel(new CustomerSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult CustomerList(CustomerSearchModel searchModel)
        {
         

            //prepare model
            var model = _customerModelFactory.PrepareCustomerListModel(searchModel);

            return Json(model);
        }
    }
}
