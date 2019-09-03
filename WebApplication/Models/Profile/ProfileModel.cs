using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Profiles.Business;

namespace WebApplication.Models.Profile
{
    public class ProfileModel
    {
        public bool IsValid { get; }

        public ProfileModel(int ID)
        {
            IsValid = false;
            ProfileCollection collection = new ProfileCollection();

            Profiles.Business.Profile userProfile = collection.GetProfile(ID);
            if (userProfile != null)
            {
                IsValid = true;
                FullName = userProfile.FirstName + " " + userProfile.LastName;
                SPIERole = userProfile.SPIERole;
                Company = userProfile.Company;
                JobTitle = userProfile.JobTitle;
                PictureFileName = userProfile.PictureFileName;
            }
        }


        public string FullName;
        public string SPIERole;
        public string Company;
        public string JobTitle;
        public string PictureFileName;
    }
}