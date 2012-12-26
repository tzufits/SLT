using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "!SLT ברוכים הבאים לאתר";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
