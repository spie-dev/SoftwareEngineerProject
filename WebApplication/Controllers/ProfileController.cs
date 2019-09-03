using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult profileView(string id)
        {
            /* Validate id parameter */
            int ID;

            try
            {
                ID = Int32.Parse(id);
            }
            catch(System.FormatException ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Index", "Home");
            }

            ProfileModel model = new ProfileModel(ID);

            if(model.Empty)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Profile", model);
        }
    }
}