using Profiles.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Login;
using System.Web.Security;


namespace WebApplication.Controllers
{
    public class AccountManagerController : Controller
    {
        // GET: AccountManager
        public ActionResult Login()
        {
            AccountManager manager = new AccountManager();

            return View(manager);
        }


        public ActionResult CheckUser()
        {
            if (ModelState.IsValid)
            {
                string userId = Request.Form["UserId"];
                string Password = Request.Form["Password"];

                Session["LoginUserId"] = "";

                var UserStatus = ProfileCollection.Instance.GetProfileByName()
                                                       .Where(x => x.UserId == userId.Trim() && x.Password == Password.Trim()).FirstOrDefault();
                if (UserStatus != null)
                {
                    Session["LoginUserId"] = userId;
                    FormsAuthentication.SetAuthCookie(userId, true);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "UserId and password are invalid, please check and try again");
                    return View("Login");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View("Login");

        }


    }
}
