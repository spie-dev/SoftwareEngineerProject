using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Profiles.Business;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string txtSearch)
        {
            ProfileCollection collection = ProfileCollection.Instance;
            IndexProfileVM profileVM = new IndexProfileVM();

            profileVM.collection = collection;

            if (txtSearch == null)
                profileVM.profile = collection.ProfileList.ToList();
            else
                profileVM.profile = collection.ProfileList
                                              .Where(x => x.FirstName.ToUpper().Contains(txtSearch.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.ToUpper()))
                                              .ToList();

            return View(profileVM);
        }
        
        public JsonResult GetProfileName(string term)
        {   

            List<string> profileNames = ProfileCollection.Instance.GetProfileByName()
                                                   .Where(x => x.FirstName.ToUpper().StartsWith(term.ToUpper()) || x.LastName.ToUpper().StartsWith(term.ToUpper()))
                                                   .Select(x => x.FirstName + ", " + x.LastName)
                                                   .ToList();

            return Json(profileNames, JsonRequestBehavior.AllowGet);
        }
        

    }
}