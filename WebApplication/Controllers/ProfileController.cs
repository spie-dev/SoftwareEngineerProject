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
            ActionResult actionResult = null;

            int result = -1;
            if (Int32.TryParse(id, out result))
            {
                ProfileModel model = new ProfileModel(Int32.Parse(id));
                if (model.IsValid)
                {
                    actionResult = View("Profile", model);
                }                
            }
           
            if (actionResult == null)
            { 
                actionResult = Redirect("~/Home/Index");
            }

            return actionResult;
        }
    }
}