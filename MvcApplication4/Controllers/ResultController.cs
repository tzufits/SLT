using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLT.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Result()
        {
         //   string filePath = Server.MapPath(Url.Content("~/Content/trans.txt"));
            string filePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));
            string[] lines = System.IO.File.ReadAllLines(filePath);
       //     string[] items;
        //    int i = 0;
          //  items = lines[i].Split('#');
            return View(lines); 
          //  return View(items); 
        }

        public ActionResult ResultNotFound()
        {
            return View(); 
        }


    }
}
