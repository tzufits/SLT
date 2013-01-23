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
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
//        public ActionResult LogOn(LogOnModel model, string returnUrl)
//        {
//            if (ModelState.IsValid)
//            {
//                if (Membership.ValidateUser(model.UserName, model.Password))
//                {
//                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
//                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
//                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
//                    {
//                        return Redirect(returnUrl);
//                    }
//                    else
//                    {
//                        return RedirectToAction("Index", "Home");
//                    }
//                }
//                else
//                {
//                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
//                }
//            }
 //                       // If we got this far, something failed, redisplay form
 //           return View(model);
 //       }

        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            string name;
            if (ModelState.IsValid)
            {
                if((name = username(model)) != "")
                {
                    FormsAuthentication.SetAuthCookie(name, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Search_trans", "Search");
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

        public string username(LogOnModel model)
        {
            //if (!System.IO.File.Exists(@"C:\Users\oener\Documents\users.txt"))
            //    return false;
            string filePath = Server.MapPath(Url.Content("~/Content/users.txt"));
            string[] arr, lines = System.IO.File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                arr = lines[i].Split('#');
                if (arr[0] == model.UserName && arr[1] == model.Password)
                    return arr[2];
            }
            return "";

        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

//        public ActionResult Register()
//      {
//            return View();
//        }

        //
        // POST: /Account/Register

//        [HttpPost]
//        public ActionResult Register(RegisterModel model)
//        {
//            if (ModelState.IsValid)
//            {
                // Attempt to register the user
//                MembershipCreateStatus createStatus;
//                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

//               if (createStatus == MembershipCreateStatus.Success)
//                {
//                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
//                }
//            }

            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded = false;
                


                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
