using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Profile;
using Profiles.Business;
using System.Web.Security;

namespace WebApplication.Controllers
{
    [RoutePrefix("profiles")]
    public class ProfileController : Controller
    {
        [Route("view/{id}")]
        public ActionResult profileView(string id)
        {
            int profitId;
            Int32.TryParse(id, out profitId);

            if(profitId == 0)
            {
                ViewData["ValidEditUser"] = "Invalid Profile id, Please check";
                return View("CustomError");
            }

            ProfileModelVM model = new ProfileModelVM(profitId);
            if (model.Empty)
            {
                ViewData["ValidEditUser"] = "Invalid Profile id, Please check";
                return View("CustomError");
            }
            return View("Profile", model);
            
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            string ProfileUser = Session["LoginUserId"] as string;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModelVM model = new ProfileModelVM(id);
            if (model.Empty)
            {
                //return HttpNotFound();
                ViewData["ValidEditUser"] = "Invalid Profile id, Please check";
                return View("CustomError");
            }

            if(ProfileUser != model.userId)
            {
                ViewData["ValidEditUser"] = "Unathorized user!! Sorry you cant edit this profile";
                return View("CustomError");

            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileModelVM profile)
        {
            if (ModelState.IsValid)
            {
                ProfileModelVM profilevm = new ProfileModelVM();
                profilevm.SaveProfile(profile);


                return RedirectToAction("Index","Home");
            }
            return View(profile);
        }


    }
}