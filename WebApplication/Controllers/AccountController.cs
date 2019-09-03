using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models.Admin;
using Profiles.Business;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // see if they are trying to login as admin, if so, send them to the Admin page
                if ((model.UserName == "admin") && (model.Password == "password"))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    Session["IsAdmin"] = true; // we need to keep track if it is the admin logged in
                    return Redirect(Url.Action("Index", "Admin"));
                }
                else // see if they are trying to login as a user
                {
                    ProfileCollection profColl = new ProfileCollection();
                    if (profColl.ValidateUserPermission(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);                        
                        return Redirect(Url.Action("Index", "Home"));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect user name or password.");
                        return View();
                    }
                }               
            }
            else
            {
                return View();
            }
        }
    }
}