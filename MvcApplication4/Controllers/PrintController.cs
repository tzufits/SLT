using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLT.Controllers
{
    public class PrintController : Controller
    {
        //
        // GET: /Print/

        public ActionResult Index()
        {
            return View();
        }

        public void print()
        {
            string printFilePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));
            string[] lines = System.IO.File.ReadAllLines(printFilePath);
            
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
