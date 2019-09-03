using Profiles.Business;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProfileCollection collection = new ProfileCollection();
            return View(collection);
        }

        public ActionResult Login()
        {
            return View();
        }

        //Log into profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string[] profile)
        {
            var obj = new Profile();

            //Checks
            if (profile == null)
                return View();
            else if (profile[0].Length == 0)
                ViewBag.Message = "Please enter a username";
            else if (profile[1].Length == 0)
                ViewBag.Message = "Please enter a password";

            //Returns if error message
            if (ViewBag.Message != null)
                return View();

            //Check if requested user exists
            ProfileCollection collection = new ProfileCollection();
            obj = collection.Login(profile[0].ToLower(), profile[1].ToLower());

            //if login was successful
            if (obj != null)
            {
                Session["UserID"] = obj.ID.ToString();
                Session["UserName"] = obj.UserName.ToString();
                return RedirectToAction("Index");
            }

            //if login was unsuccessful
            ViewBag.Message = "Invalid username or password.";
            return View();
        }

        //Log out of profile
        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }


    }
}