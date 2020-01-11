using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Models.Cms;
using CreativeTim.Argon.DotNetCore.Free.Models.BaseListModel;
using CreativeTim.Argon.DotNetCore.Free.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Service.Catalog;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class CustomerController : Controller
    {
        private IUserService _userService;
        public CustomerController(IUserService UserService)
        {
            this._userService = UserService;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return PartialView();
        }
        public IActionResult Edit(int id)
        {
            var entity = _userService.GetById(id);
            var model = new UserModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Phone = entity.Phone;
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult List(CustomerSearchModel searchModel)
        {
            var model = _userService.GetAll(searchModel.Start,searchModel.Length);
            var list = new CustomerListModel();
             list.data = model.Select(x=>new UserModel {
                Id=x.Id,
                Name=x.Name

            });
            list.recordsTotal = model.TotalCount;
            list.recordsFiltered = model.Count;
            list.draw = searchModel.Draw;
          
   
           return Json(list);
        }
    }
}