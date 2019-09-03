using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ProfileContext db = new ProfileContext())
            {
                return View(db.Profiles.ToList());
            }
        }

    }
}