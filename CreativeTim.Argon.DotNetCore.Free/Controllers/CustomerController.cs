using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Models.Cms;
using CreativeTim.Argon.DotNetCore.Free.Models.BaseListModel;
using CreativeTim.Argon.DotNetCore.Free.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Service.Catalog;
using Domain.Models;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using AutoMapper;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CustomerController(IUserService UserService, IMapper mapper)
        {
            this._userService = UserService;
            _mapper = mapper;
        }

        [HttpGet("/Customer/List")]
        public IActionResult List()
        {
            return View();
        }
        [HttpGet("/Customer/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var entity = _userService.GetById(id);
            var model = _mapper.Map<UserModel>(entity);
            return View(model);
        }
        [HttpPost("/Customer/List")]
        public JsonResult List(CustomerSearchModel searchModel)
        {
            var entitymodel = _userService.GetAll(searchModel.Start,searchModel.Length);
            var list = new CustomerListModel();
            list.data = entitymodel.Select(x =>  {
                var modelview = _mapper.Map<UserModel>(x);
                return modelview;
            });
            list.recordsTotal = entitymodel.TotalCount;
            list.recordsFiltered = entitymodel.Count;
            list.draw = searchModel.Draw;
           return Json(list);
        }
        [HttpPost("/Customer/Edit")]
        public IActionResult Edit([FromBody]UserModel customer)
        {         
                var user = _userService.GetById(customer.Id);
                if (user != null)
                {
                    user.Name = customer.Name;
                    user.Phone = customer.Phone;
                    user.Email = customer.Email;
                    user.Address = customer.Address;
                    user.Gender = customer.Gender;
                    user.Company = customer.Company;
                    user.Company = customer.Company;
                    user.UpdatedOn = DateTime.Now;
                  
                _userService.Update(user);
                    return Json(1);
                 }
                return Json(0);
        }
        [HttpGet("/Customer/Add")]
        public IActionResult Add()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost("/Customer/Add")]
        public IActionResult Add([FromBody]UserModel model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                user.CreatedOn = DateTime.Now;
                _userService.Insert(user);
                user.Guid = Guid.NewGuid();
                return Json(1);
            }

            catch
            {
                return Json(0);
            }
      
        }

        [HttpPost("/Customer/Delete/{id}")]
        public JsonResult Delete(int Id)
        {
            try
            {
                var user = _userService.GetById(Id);
                _userService.Delete(user);
                return Json(1);
            }

            catch
            {
                return Json(0);
            }

        }
    }
}