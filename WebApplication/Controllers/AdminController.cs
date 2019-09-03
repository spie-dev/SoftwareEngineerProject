using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profiles.Business;

namespace WebApplication.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ProfileCollection repository = new ProfileCollection();

        public ActionResult Index()
        {
            ActionResult viewResult = null;

            // make sure this is an admin           
            if (Session["IsAdmin"] != null)
            {
                if ((bool)Session["IsAdmin"])
                {
                    viewResult = View(repository);
                }
            }

            if (viewResult == null)
            {
                // if they are NOT an admin, send them back to the login page
                viewResult = Redirect("/Account/Login");
            }

            return viewResult;
        }

        public ActionResult Edit(int id)
        {
            ActionResult viewResult = null;

            Profile profile = repository.GetProfile(id);
            if (profile == null)
            {
                viewResult = Redirect("~/Admin/Index");
            }
            else
            {
                viewResult = View(profile);
            }

            return viewResult;
        }

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                bool bSuccess = repository.Save(profile);
                if (bSuccess)
                {
                    TempData["message"] = string.Format("{0} has been saved", profile.FirstName + " " + profile.LastName);
                }
                else
                {
                    TempData["message"] = string.Format("There was an error saving the changes. {0} has NOT been saved", profile.FirstName + " " + profile.LastName);
                }

                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(profile);
            }
        }
    }
}