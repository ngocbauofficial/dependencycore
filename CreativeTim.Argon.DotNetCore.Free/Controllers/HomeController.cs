using System.Diagnostics;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using CreativeTim.Argon.DotNetCore.Free.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Service.Catalog;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public  HomeController(IUserService userService)
        {
           this._userService= userService;
        }

      //  [HttpGet("/")]
        public IActionResult Index()
        {
            ViewBag.Language ="vi-VN";

            return View();
        }

     //   [HttpGet("/icons")]
        public IActionResult Icons()
        {
            return PartialView();
        }
        public IActionResult Home()
        {
            return PartialView();
        }

        [HttpGet("/maps")]
        public IActionResult Maps()
        {
            return PartialView();
        }

 
        [HttpGet("/profile")]
        public IActionResult Profile()
        {
     
            return View();
        }


        [HttpPost("/profile")]
        public  IActionResult UpdateProfile() { 
            return View();
        }

      //  [HttpGet("/tables")]
        public IActionResult Tables()
        {
            return PartialView();
        }

        [HttpGet("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/status-code")]
        public IActionResult StatusCodeHandler(int code)
        {
            ViewBag.StatusCode = code;
            ViewBag.StatusCodeDescription = ReasonPhrases.GetReasonPhrase(code);
            ViewBag.OriginalUrl = null;


            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                ViewBag.OriginalUrl =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }

            if (code == 404)
            {
                return View("Status404");
            }

            return View("Status4xx");
        }
    }
}
