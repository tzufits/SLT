using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLT.Models;

namespace SLT.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Result()
        {
         
            string filePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));
            string[] lines = System.IO.File.ReadAllLines(filePath);
       
            return View(lines); 
          
        }

        [HttpPost]

        public ActionResult Result(string returnUrl)
        {
            return RedirectToAction("Search_trans", "Search");
        }

        public ActionResult ResultNotFound(SearchModel model)//*TRY
        {
            // string[] arrays={model.firstName, model.Last, model.Day, model.FromHour, model.City, model.Sex};//

            return View(); 
        }


    }
}
