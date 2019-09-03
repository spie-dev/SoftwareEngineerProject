using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Profiles.Business;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index(string search)
        {
            ProfileCollection collection = new ProfileCollection(search);            
            return View(collection);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); 
            Session["IsAdmin"] = false;
            return Redirect("/Home/Index");
        }
    }
}