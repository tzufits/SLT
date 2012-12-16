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
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]

        public ActionResult LogOn(SearchModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(model.Day == "sun")
                {
                    FormsAuthentication.SetAuthCookie(model.Day, model.Sex);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("","");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public Boolean isExists(LogOnModel model)
        {
            if (!System.IO.File.Exists(@"C:\Users\oener\Documents\trans.txt"))
                return false;

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\oener\Documents\trans.txt");

            for (int i = 0; i < lines.Length; i++)
                if (lines[i] == model.UserName && lines[i + 1] == model.Password)
                    return true;
                else
                    i++;
            return false;

        }

    }
}
