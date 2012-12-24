using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MvcApplication4.Models;
using System.IO;


namespace MvcApplication4.Controllers
{
    public class printend : Controller
    {
        public void print()
        {
         //   string printFilePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));
         //   string[] lines = System.IO.File.ReadAllLines(printFilePath);
          //  for (int i = 0; i < lines.Length; i++)
          //  {
          //      Console.WriteLine(lines[i]);
          //  }


            for (int i = 0; i < 3; ++i)
            { Console.WriteLine("Welcome"); }

        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
