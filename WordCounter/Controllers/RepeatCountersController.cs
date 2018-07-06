using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordCounter.Models;

namespace WordCounter.Controllers
{
    public class RepeatCountersController : Controller
    {
        [HttpGet("/repeatcounters")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/repeatcounters/new")]
        public ActionResult Search()
        {
            return View();
        }
    }
}
