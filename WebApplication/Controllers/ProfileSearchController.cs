using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileSearchController : Controller
    {
        // GET: ProfileSearch
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(string s)
        {
            List<ProfileSearchModel> results = ProfileSearchModel.Search(s);

            return new JsonResult { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}