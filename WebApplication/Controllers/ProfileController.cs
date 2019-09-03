using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileContext db = new ProfileContext();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult profileView(string id)
        {
            try
            {
                ProfileModel model = db.Profiles.Find(Int32.Parse(id));
                return View("Profile", model);
            }
            catch
            {
                // TODO: bad input, may be prudent to log for bug hunting or security concerns
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            try
            {
                ProfileModel model = db.Profiles.Find(id);
                return View("ProfileEdit", model);
            }
            catch
            {
                // TODO: [invalid id] may be prudent to log for bug hunting or security concerns
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Save(ProfileModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                ProfileModel toUpdate = db.Profiles.Find(model.Id);
                if (TryUpdateModel<ProfileModel>(toUpdate))
                    db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ProfileController Error", ex.Message.ToString());
            }
            return View("ProfileEdit", model);
        }

    }
}