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
        public int flag = 0;

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
                else if(flag == 1)
                    ModelState.AddModelError("", "");
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
            int count = 0;
            string filePath = Server.MapPath(Url.Content("~/Content/trans.txt"));
            string printFilePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));
            string first, last; 
            string[] items, lines = System.IO.File.ReadAllLines(filePath), matchTrans = new string[lines.Length];
            bool isMatch = true;
            StreamWriter sw = new StreamWriter(printFilePath);

            matchTrans[0] = "000";
            if (model.firstName == null)
                first = "null";
            else
                first = model.firstName;
            if (model.lastName == null)
                last = "null";
            else
                last = model.lastName;
            
            // put the searchModel values into an array
            string[] array = {first,last,model.Day,model.City,model.Sex,model.FromHour,model.ToHour,"null"};
            
            for( int i=0; i<lines.Length;i++)
            while(i<lines.Length)
            {
                items = lines[i].Split('#');
                isMatch = compare(items, array);
                if (isMatch == true)
                {
                    if (isTransExists(matchTrans, items[8]) == false)
                    {
                        matchTrans[count] = items[8];
                        sw.Write(items[0] + " " + items[1] + " " + items[7] + "\r\n");
                        count++;
                    }
                    isMatch = false;
                }
                i++;
            }
            sw.Close();

            if (count > 0)
                return true;
            else
                return false;
          
        }

        public Boolean compare(string[] items, string[] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                if ((arrays[5] != "null") && (arrays[6] != "null"))
                    if (hours(items, arrays) == false)
                        return false;
                if (arrays[i] != "null")
                {
                    if ((i == 5) || (i == 6))
                        continue;
                    if (arrays[i] != items[i])
                        return false;
                }
            }
            return true;
        }

        public Boolean hours(string[] items, string[] arrays)
        {      
            int num = Convert.ToInt32(items[5], 10);
            int num2 = Convert.ToInt32(items[6], 10);
            int numarr = Convert.ToInt32(arrays[5], 10);
            int numarr2 = Convert.ToInt32(arrays[6], 10);

            if (numarr > numarr2)//if to big from from
            {
                flag = 1;
                return false;
            }
            if ((numarr <= num) && (numarr2 >= num2))
                return true;
            return false;
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
