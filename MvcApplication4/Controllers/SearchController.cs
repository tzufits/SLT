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
                if (isExists(model)==true)//my
                {//**my
                    

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    { //return RedirectToAction("Index", "printend");
                        return RedirectToAction("Result", "Result");
                    }
                    //   }
                }
                else//***my
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
            //if (!System.IO.File.Exists(@"C:\Users\oener\Documents\users.txt"))
            //    return false;
            string filePath = Server.MapPath(Url.Content("~/Content/trans.txt"));
             string printFilePath = Server.MapPath(Url.Content("~/Content/toPrint.txt"));

           // System.IO.StreamWriter file2 = new System.IO.StreamWriter(printFilePath);


   // string[] arrays={model.First, model.Last, model.Day, model.FromHour, model.City, model.Sex};// put the searchModel values into an array
     //try 
    string[] arrays={"moran", "moshe", "rison", "13:00", "uro", "male",null};

    bool flag2=true;
    string[] items;
    int finder = 1;

    string[] lines= System.IO.File.ReadAllLines(filePath);

      //  for (int i = 0; i < lines.Length; i++)
    for (int i = 0; i < 3; i++)
          {
          
             items= lines[i].Split('#');
        

           flag2 = isExists2(items, arrays);
          if (flag2==true)
          {
              finder++;
             // string final= arrays[0]+arrays[1]+arrays[6];
              string final = "found";  

               using (StreamWriter sw = System.IO.File.AppendText(printFilePath)) 
                 {
                   sw.WriteLine(final);
                    }
               flag2 = false;

           }

        }
        if (finder > 0)
            return true;
        else
            return false;
}

        public Boolean isExists2(string[] items, string[] arrays)
        {

            for (int i = 0; i < 5; i++)
            {
                if (items[i] != null)
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
