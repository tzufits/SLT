using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLT.Models;
using System.IO;

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

        public ActionResult Print_list()
        {
            int i = 0, count = 0;
            string filePath = Server.MapPath(Url.Content("~/Content/trans.txt"));
            string printFilePath = Server.MapPath(Url.Content("~/Content/transList.txt"));
            string[] items, lines = System.IO.File.ReadAllLines(filePath), list = System.IO.File.ReadAllLines(printFilePath);
            string[] matchTrans = new string[lines.Length];

            StreamWriter sw = new StreamWriter(printFilePath);

            while (i < lines.Length)
            {
                items = lines[i].Split('#');
 
                if (isTransExists(matchTrans, items[8]) == false)
                {
                    matchTrans[count] = items[8];
                    sw.Write(items[0] + " " + items[1] + " " + items[7] + "\r\n");
                    count++;
                }
                i++;
            }
            sw.Close();
            return View(list);
        }

        public Boolean isTransExists(string[] matchTrans, string id)
        {
            for (int i = 0; i < matchTrans.Length; i++)
                if (matchTrans[i] == id)
                    return true;
            return false;
        }
    }
}
