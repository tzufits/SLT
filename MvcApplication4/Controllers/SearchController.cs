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
            string first;
            string last;
            if (model.First == null)
                first = "null";
            else
                first = model.First;

            if (model.Last == null)
                last = "null";
            else
                last = model.Last;

        string[] arrays={first,last,model.Day,model.City,model.Sex,model.FromHour,model.ToHour,"null"};// put the searchModel values into an array
         
            bool flag2 = true;
            string[] items;
            int finder = 0;

            string[] lines = System.IO.File.ReadAllLines(filePath);


            StreamWriter sw = new StreamWriter(printFilePath);
            

            for (int i = 0; i < lines.Length; i++)
            {
                
                items = lines[i].Split('#');
                
                flag2 = isExists2(items, arrays);
              //  sw.Write("flag "+ flag2+"\r\n");

                if (flag2 == true)
                {
                    finder++;

                    sw.Write(items[0] + " " + items[1] + " " + items[7] + "\r\n");

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

                
                    if (arrays[i] != "null")
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