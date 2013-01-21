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
            int i=0;
            while(i < lines.Length)
            {
                
                items = lines[i].Split('#');
                
                flag2 =compare(items, arrays);



                if (flag2 == true)
                {
                    finder++;

                    sw.Write(items[0] + " " + items[1] + " " + items[7] + "\r\n");

                    flag2 = false;
                }

                i++;
               
            }

          sw.Close();

          if (finder > 0)
              return true;
          else
              return false;
          
        }





        public Boolean compare(string[] items, string[] arrays)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                    if (hours(items,arrays)==false)
                        return false;
                
                    if (arrays[i] != "null")
                    {
                        if ((i == 5) || (i == 6))
                            continue;

                        if (arrays[i] != items[i])
                        {
                            return false;
                        }

                    }
                
            }
  
            return true;

        }



        public Boolean hours(string[] items, string[] arrays)
        {

            if ((arrays[5] != "null") && (arrays[6] != "null"))
            {
                int num = Convert.ToInt32(items[5], 10);
                int num2 = Convert.ToInt32(items[6], 10);

                int numarr = Convert.ToInt32(arrays[5], 10);
                int numarr2 = Convert.ToInt32(arrays[6], 10);

                if (numarr > numarr2)//if to big from from
                    return false;


                if ((numarr >= num) && (numarr <= num2) && (numarr2 >= num) && (numarr2 <= num2))
                    return true;
               

            }

            return false;
      
        }
    }
}
