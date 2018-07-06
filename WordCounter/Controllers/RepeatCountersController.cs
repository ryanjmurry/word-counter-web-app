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

        [HttpGet("/repeatcounters/history")]
        public ActionResult History()
        {
            List<RepeatCounter> history = RepeatCounter.GetHistory();
            return View(history);
        }

        [HttpPost("/repeatcounters/results")]
        public ActionResult Results()
        {
            RepeatCounter newRepeatCounter = new RepeatCounter(Request.Form["target-word"], Request.Form["search-phrase"]);
            newRepeatCounter.SetMatches();
            return View(newRepeatCounter);
        }

        [HttpGet("/repeatcounters/{id}")]
        public ActionResult Details(int id)
        {
            RepeatCounter current = RepeatCounter.Find(id);
            return View(current);
        }

        [HttpPost("/repeatcounters")]
        public ActionResult DeleteSearches()
        {
            RepeatCounter.ClearHistory();
            return RedirectToAction("Index");
        }

        [HttpPost("/repeatcounters/{id}")]
        public ActionResult ClearSearch(int id)
        {
            RepeatCounter.ClearOne(id);
            return RedirectToAction("History");
        }
    }
}
