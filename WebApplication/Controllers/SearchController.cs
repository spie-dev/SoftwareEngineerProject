using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult searchView(string id)
        {
            Profiles.Business.ProfileCollection profiles = new Profiles.Business.ProfileCollection();
            var model = profiles.Search(id);

            return View("Search", model);
        }
    }
}