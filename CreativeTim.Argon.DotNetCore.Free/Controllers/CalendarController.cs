using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Service.Catalog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class CalendarController : BaseController
    {
        private readonly ICalendarService _calendarService;
        private readonly IMapper _mapper;
        public CalendarController(ICalendarService CalendarService, IMapper mapper)
        {
            this._calendarService = CalendarService;
            _mapper = mapper;
        }
        [HttpGet("/Calendar")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Calendar/ListCalendar")]
        public IActionResult ListAll()
        {
            var list = _calendarService.GetAll().ToList();

            return Json(list);
        }
    }
}
