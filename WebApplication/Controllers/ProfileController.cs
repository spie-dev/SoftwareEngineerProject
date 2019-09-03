using Profiles.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        //View a profile
        public ActionResult profileView(string id)
        {
            //Check if id is an int
            if (!Int32.TryParse(id, out int idInt))
                return Redirect("~/");

            //Fill model and check if valid
            ProfileModel model = new ProfileModel(idInt);
            if (model.FullName == null)
            {
                return Redirect("~/");
            }

            return View("Profile", model);
        }

        //Edit a profile
        public ActionResult Edit()
        {
            //Check if editing logged in user
            var userID = Session["UserID"];
            if (userID == null || !int.TryParse(userID.ToString(), out int userIDNum))
            {
                return Redirect("~/");
            }

            ProfileCollection collection = new ProfileCollection();

            //Get this user's current profile
            var currentProfile = collection.GetProfile(userIDNum);

            return View("Edit", currentProfile);
        }

        //Edit submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profile profile)
        {
            var userID = Session["UserID"];
            if (userID == null || !int.TryParse(userID.ToString(), out int userIDNum))
            {
                return Redirect("~/");
            }

            ProfileCollection collection = new ProfileCollection();

            //Get this user's current profile
            var currentProfile = collection.GetProfile(userIDNum);

            if (profile.FirstName != null)
            {
                //Update with new values
                currentProfile.FirstName = profile.FirstName;
                currentProfile.LastName = profile.LastName;
                currentProfile.Company = profile.Company;
                currentProfile.SPIERole = profile.SPIERole;
                currentProfile.JobTitle = profile.JobTitle;

                //Update "database"
                if (collection.EditUser(currentProfile))
                {
                    return Redirect("/profiles/view/" + currentProfile.ID);
                }
            }

            return View(currentProfile);
        }

        //Add a new profile
        public ActionResult NewUser()
        {
            ProfileCollection collection = new ProfileCollection();

            return View();
        }

        //New user submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUser(Profile profile)
        {
            const string imagePath = "/Images/ProfilePictures/";
            ProfileCollection collection = new ProfileCollection();

            var file = Request.Files["PictureFileName"];

            if (profile.FirstName != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string fileExtension = Path.GetExtension(file.FileName);
                List<string> allowedFileTypes = new List<string> { "png", "jpeg", "jpg", "gif" };

                if (!allowedFileTypes.Contains(fileExtension.Substring(1).ToLower()))
                {
                    ViewBag.Message = "Not a valid image format";
                    return View();
                }

                //Add Current Date To Attached File Name
                fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + fileName.Trim() + fileExtension;

                profile.PictureFileName = fileName;
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + imagePath);

                //Limit size of image
                WebImage img = new WebImage(file.InputStream);
                if (img.Width > 200)
                    img.Resize(200, 200);

                //Save image
                img.Save(AppDomain.CurrentDomain.BaseDirectory + imagePath + fileName);

                //Add user to "database"
                string[] user = collection.AddUser(profile);

                //Log user in
                Session["UserID"] = user[0];
                Session["UserName"] = user[1];

                return Redirect("/profiles/view/" + profile.ID);
            }

            return View();
        }
    }
}