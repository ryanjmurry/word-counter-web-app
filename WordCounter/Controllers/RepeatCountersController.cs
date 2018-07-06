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
            List<RepeatCounter> history = RepeatCounter.GetHistory();
            return View(history);
        }

        [HttpGet("/repeatcounters/new")]
        public ActionResult Search()
        {
            return View();
        }

        [HttpGet("/repeatcounters/history")]
        public ActionResult History()
        {
            return View();
        }

        [HttpPost("/repeatcounters")]
        public ActionResult Create()
        {
            RepeatCounter newRepeatCounter = new RepeatCounter(Request.Form["target-word"], Request.Form["search-phrase"]);
            return RedirectToAction("Index");
        }
    }
}
