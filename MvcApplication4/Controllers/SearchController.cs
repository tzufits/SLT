using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SLT.Models;
using System.IO;


namespace SLT.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Search_trans()
        {
            
            return View();
        }




        [HttpPost]

        public ActionResult Search_trans(SearchModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (isExists(model) == true)
                {
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    { 
                        return RedirectToAction("Result", "Result");
                    }
                   
                }
                else
                {
                    return RedirectToAction("ResultNotFound", "Result");
                }
            }
            else
            {
                ModelState.AddModelError("", "");
            }

            // If we got this far, something failed, redisplay form
            return View(model);

        }





        public Boolean isExists(SearchModel model)
        {

            string filePath = Server.MapPath(Url.Content("~/Content/trans.txt"));
            string printFilePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));

           
            // string[] arrays={model.First, model.Last, model.Day, model.FromHour, model.City, model.Sex};// put the searchModel values into an array


            string[] arrays = { "moran", "moshe", "rison", "13:00", "uro", "male", null };
           // string[] arrays = { "natali", null, null, null, null, null, null };
            bool flag2 = true;
            string[] items;
            int finder = 0;

            string[] lines = System.IO.File.ReadAllLines(filePath);


            StreamWriter sw = new StreamWriter(printFilePath);
           // sw.WriteLine("");

            for (int i = 0; i < lines.Length; i++)
            {

                items = lines[i].Split('#');

                flag2 = isExists2(items, arrays);

                if (flag2 == true)
                {
                    finder++;
                 
                    sw.Write(items[0] + " "+items[1] +" "+ items[6]+"\r\n");
          
                    flag2 = false;
                }
               
            }

          sw.Close();
     
            if (finder > 0)
                return true;
            else
                return false;
        }






        public Boolean isExists2(string[] items, string[] arrays)
        {

            for (int i = 0; i < arrays.Length; i++)
            {
                if (arrays[i] != null)
                {
                    if (arrays[i] != items[i])
                    {

                        return false;
                    }

                }
            }
            return true;

        }
    }
}