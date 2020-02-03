using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service.Catalog;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("/Account/GetLogin")]
        public IActionResult Login(string UserName, string PassWord)
        {
           var user = _accountService.GetLogin(UserName, PassWord);
            if(user == 1)
            {
                return Json(new { result = "1", url = "/Home" });
            }
            return Json(new { result = "2" });
        }
    }
}