using Profiles.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search(string id)
        {
            ProfileCollection collection = new ProfileCollection();

            return View("Search", collection.GetProfiles(id));
        }
    }
}