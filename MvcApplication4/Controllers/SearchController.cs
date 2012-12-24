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
                //  if(isExists(model))

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

            string[] lines = System.IO.File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
                if (lines[i] == model.Day && lines[i + 1] == model.City && lines[i + 2] == model.Sex)
                    return true;
                else
                    i += 2;
            return false;
        }
    }
}
