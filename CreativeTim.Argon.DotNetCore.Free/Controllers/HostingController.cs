using AutoMapper;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using CreativeTim.Argon.DotNetCore.Free.Models.BaseListModel;
using CreativeTim.Argon.DotNetCore.Free.Models.Cms;
using CreativeTim.Argon.DotNetCore.Free.Models.Search;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class HostingController:BaseController
    {
        private readonly IHostingService _hostingService;
        private readonly IMapper _mapper;
        public HostingController(IHostingService UserService, IMapper mapper)
        {
            this._hostingService = UserService;
            _mapper = mapper;
        }
        [HttpGet("/Hosting/List")]
        public IActionResult List()
        {
            return View();
        }
        [HttpPost("/Hosting/List")]
        public IActionResult List(HostingSearchModel searchModel)
        {
            var entitymodel = _hostingService.GetAll(searchModel.Start, searchModel.Length);
            var list = new HostingListModel();
            list.data = entitymodel.Select(x => {
                var modelview = _mapper.Map<HostingModel>(x);
                return modelview;
            });
            list.recordsTotal = entitymodel.TotalCount;
            list.recordsFiltered = entitymodel.Count;
            list.draw = searchModel.Draw;
            return Json(list);
       
        }
        [HttpPost("/Hosting/Edit")]
        public IActionResult Edit([FromBody]HostingModel hosting)
        {
            var hostingentity = _hostingService.GetHostingById (hosting.Id);
            if (hostingentity != null)
            {
                hostingentity.HostingIp = hosting.HostingIp;
                hostingentity.HostingName = hosting.HostingName;
                hostingentity.LinkLogin = hosting.LinkLogin;
                hostingentity.Password = hosting.Password;
                hostingentity.UserName = hosting.UserName;
                hostingentity.Vendor = hosting.Vendor;
                _hostingService.Update(hostingentity);
                return Json(1);
            }
            return Json(0);
        }
        [HttpGet("/Hosting/Add")]
        public IActionResult Add()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost("/Hosting/Add")]
        public IActionResult Add([FromBody]HostingModel model)
        {
            try
            {
                var hosting = _mapper.Map<Hosting>(model);
                _hostingService.Insert(hosting);
                return Json(1);
            }
            catch
            {
                return Json(0);
            }
        }

        [HttpPost("/Hosting/Delete/{id}")]
        public JsonResult Delete(int Id)
        {
            try
            {
                var hosting  = _hostingService.GetHostingById(Id);
                _hostingService.Delete(hosting);
                return Json(1);
            }
            catch
            {
                return Json(0);
            }

        }
    }
}
